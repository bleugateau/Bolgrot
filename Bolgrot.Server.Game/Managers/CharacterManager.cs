﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Autofac;
using Bolgrot.Core.Ankama.Protocol.Data;
using Bolgrot.Core.Ankama.Protocol.Enums;
using Bolgrot.Core.Ankama.Protocol.Messages;
using Bolgrot.Core.Ankama.Protocol.SendMessages;
using Bolgrot.Core.Ankama.Protocol.Types;
using Bolgrot.Core.Ankama.Protocol.Utils;
using Bolgrot.Core.Common.Entity;
using Bolgrot.Core.Common.Repository;
using Bolgrot.Server.Game.Frames;
using Bolgrot.Server.Game.Network;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NLog;

namespace Bolgrot.Server.Game.Managers
{
    public interface ICharacterManager
    {
        public Dictionary<int, Heads> HeadsData { get; }
        public Dictionary<int, Breeds> BreedsData { get; }
        public Task CreateCharacter(GameClient client, CharacterCreationRequestMessage characterCreationRequestMessage);
        public Task CharacterDeletion(GameClient client, CharacterDeletionRequestMessage characterDeletionRequestMessage);
        public Task CharacterSelection(GameClient client, int selectedCharacterId);
    }
    
    public class CharacterManager : AbstractGameManager, ICharacterManager
    {
        public Dictionary<int, Heads> HeadsData { get; }
        public Dictionary<int, Breeds> BreedsData { get; }

        private static readonly Regex NAME_REGEX = new Regex("^[A-Za-z]{3,20}$", RegexOptions.Compiled);
        private static int MIN_PLAYER_NAME_LENGTH = 2;
        private static int MAX_PLAYER_NAME_LENGTH = 20;
        private static int CONFIRM_DELETION_LVL = 20;
        
        private ICharacterRepository _characterRepository;
        private IMapManager _mapManager;

        public CharacterManager(ICharacterRepository characterRepository, IMapManager mapManager)
        {
            this._characterRepository = characterRepository;
            this._mapManager = mapManager;

            this._logger.Info("CharacterManager loading...");
            
            this.HeadsData = this.LoadGameData<Heads>();
            this.BreedsData = this.LoadGameData<Breeds>();
        }

        /**
         * Handle character creation frame
         */
        public Task CreateCharacter(GameClient client, CharacterCreationRequestMessage characterCreationRequestMessage)
        {
            var characterAlreadyExist = this._characterRepository.Entities().Values
                .FirstOrDefault(x => x.Name == characterCreationRequestMessage.name);

            //check if account with name already exist
            if (characterAlreadyExist != null)
            {
                client.Send(new CharacterCreationResultMessage((int)CharacterCreationResultEnum.ERR_NAME_ALREADY_EXISTS));
                return null;
            }

            //check length of name
            if (!this.VerifCharacterName(characterCreationRequestMessage.name))
            {
                client.Send(new CharacterCreationResultMessage((int)CharacterCreationResultEnum.ERR_INVALID_NAME));
                return null;
            }
            
            //check if valid colors
            if (!characterCreationRequestMessage.colors.All(x => x >= 0))
            {
                client.Send(new CharacterCreationResultMessage((int)CharacterCreationResultEnum.ERR_NOT_ALLOWED));
                return null;
            }

            var numberOfCharacters = this._characterRepository.Entities().Values.Count(x => x.AccountId == 1);

            //check if account has too many characters created
            if (numberOfCharacters >= 6)
            {
                client.Send(new CharacterCreationResultMessage((int)CharacterCreationResultEnum.ERR_TOO_MANY_CHARACTERS));
                return null;
            }
            
            //find head by cosmeticId
            this.HeadsData.TryGetValue(characterCreationRequestMessage.cosmeticId, out Heads head);

            //check if cosmeticId is correspond to sex + breed
            if (head == null || Convert.ToBoolean(head.Gender) != characterCreationRequestMessage.sex ||
                head.Breed != characterCreationRequestMessage.breed)
            {
                client.Send(new CharacterCreationResultMessage((int)CharacterCreationResultEnum.ERR_NOT_ALLOWED));
                return null;
            }

            var character = new Character();
            //character.Id = this.GenerateId();
            character.AccountId = client.Account.Id;
            character.Breed = characterCreationRequestMessage.breed;
            character.Sex = characterCreationRequestMessage.sex;
            character.Level = 200; //from config
            character.MapId = 81266690;
            character.CellId = 298;
            character.Experiences = 0;
            character.Name = characterCreationRequestMessage.name;
            character.EntityLookData = JsonConvert.SerializeObject(new EntityLook()
            {
                bonesId = 1,
                scales = new int[]{125},
                indexedColors = characterCreationRequestMessage.colors,
                skins = new int[] {Convert.ToInt32(head.AssetId.Split("_")[0]), (int)head.Skins},
                subentities = new SubEntity[] {}
            });

            this._characterRepository.AddEntity(character);

            client.Send(new CharacterCreationResultMessage((int)CharacterCreationResultEnum.OK));
            
            ApproachFrames.SendCharactersListMessage(client);

            return Task.CompletedTask;
        }

        /**
         * Handle character deletion frame
         */
        public Task CharacterDeletion(GameClient client, CharacterDeletionRequestMessage characterDeletionRequestMessage)
        {
            var character = this._characterRepository.Entities().Values.FirstOrDefault(x =>
                x.Id == characterDeletionRequestMessage.characterId && x.AccountId == 1);
            
            //check if accountid and characterId are linked
            if (character == null)
            {
                client.Disconnect();
                return null;
            }
            
            //if level > 20 need valid answer for delete character
            var exceptedSecretAnswerHash = CryptographyHelper.Md5(character.Id.ToString() + "~000000000000000000");

            if (character.Level >= CharacterManager.CONFIRM_DELETION_LVL)
            {
                exceptedSecretAnswerHash = CryptographyHelper.Md5(character.Id.ToString() + "~" + "DELETE"); //@IPC in future
                if (exceptedSecretAnswerHash == characterDeletionRequestMessage.secretAnswerHash)
                {
                    this._characterRepository.DeleteEntity(character);
                }
            }
            else
            {
                if (exceptedSecretAnswerHash == characterDeletionRequestMessage.secretAnswerHash)
                {
                    this._characterRepository.DeleteEntity(character);
                }
            }
            
            
            ApproachFrames.SendCharactersListMessage(client);
            
            return Task.CompletedTask;
        }


        /**
         * Handle character selection frame
         */
        public async Task CharacterSelection(GameClient client, int selectedCharacterId)
        {
            var character = this._characterRepository.Entities().Values
                .FirstOrDefault(x => x.Id == selectedCharacterId && x.AccountId == client.Account.Id); //@TODO ipc

            if (character == null)
            {
                client.Send(new CharacterSelectedErrorMessage());
                return;
            }
            
            var map = await this._mapManager.GetMapById(character.MapId);
            if (map == null)
            {
                client.Send(new CharacterSelectedErrorMessage());
                return;
            }

            client.Character = character;

            //add character to map
            map.Characters.TryAdd(client.Character.Id, client.Character);

            client.Send(new TowerOfAscensionResultsMessage(new int[] { })); //???
            client.Send(new NotificationListMessage(new int[] {2591762, 196626 }));
            client.Send(new CharacterSelectedSuccessMessage(character.ToCharacterBaseInformations()));
            
            client.Send(new InventoryContentMessage(new ObjectItem[]
            {
                new ObjectItem(63, 8545, new ObjectEffectInteger[]{}, 1, 1500 ), 
                new ObjectItem(63, 8876, new ObjectEffectInteger[]{}, 1, 20 ), 
            }, 1000));
            
            client.Send(new ShortcutBarContentMessage(0, new ShortcutSpell[] {})); //manage two Shortcut type
            client.Send(new ShortcutBarContentMessage(1, new ShortcutSpell[] {}));
            
            client.Send(new EmoteListMessage(new int[] {}));
            client.Send(new AlignmentRankUpdateMessage(0, false));


            client.Send(new EnabledChannelsMessage(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 12, 13, 9, 10 }, new int[] { 8 }));

            client.Send(new SequenceNumberRequestMessage());
            
            client.Send(new TextInformationMessage(1, 89, new int[] { }, Container.Instance().Resolve<ILangManager>().GetLang(1, client.Language)));
            //switch (client.Language)
            //{
            //    case "fr":
            //        client.Send(new TextInformationMessage(1, 89, new int[] { }, "Bienvenue sur <b>Bolgrot</b>, serveur en version BETA développé par Ten !"));
            //        break;
            //    case "pt":
            //        client.Send(new TextInformationMessage(1, 89, new int[] { }, "Bem-vindo ao <b>Bolgrot</b>, servidor em versão BETA desenvolvido por Ten !"));
            //        break;
            //    case "es":
            //        client.Send(new TextInformationMessage(1, 89, new int[] { }, "Bienvenue sur <b>Bolgrot</b>, serveur en version BETA développé par Ten !"));
            //        break;
            //    default:
            //        client.Send(new TextInformationMessage(1, 89, new int[] { }, "Bienvenue sur <b>Bolgrot</b>, serveur en version BETA développé par Ten !"));
            //        break;
            //}

            client.Send(new TitlesAndOrnamentsListMessage(new int[] { }, new int[] { }, 0, 0));

            client.Send(new SpouseStatusMessage(false));
            client.Send(new AchievementListMessage(new int[] { }, new int[] { }, new AchievementAccount[] { }, new int[] { }, new { points="4" ,  achievementsTotal="1064"  }));
            client.Send(new GameRolePlayArenaUpdatePlayerInfosMessage(1,0,0,0,0));
            client.Send(new CharacterCapabilitiesMessage(4095)); //guild emblem
            client.Send(new AlmanachCalendarDateMessage(69, "Jeffarctor"));
            client.Send(new MailStatusMessage(0, 0));            
            client.Send(new StartupActionsListMessage(new int[] {})); //startup action = ?? gift i think
            client.Send(new QuestListMessage(new int[] { }, new int[] { }, new int[] { }));
            //setShopDetailsSuccess skip 
            client.Send(new FriendsListMessage(new int[] { }));
            client.Send(new IgnoredListMessage(new int[] { }));
            

        }

        /**
         * Return true if character name is valid
         */
        private bool VerifCharacterName(string name)
        {
            //check length of name
            if (name.Length < CharacterManager.MIN_PLAYER_NAME_LENGTH ||
                name.Length > CharacterManager.MAX_PLAYER_NAME_LENGTH)
            {
                return false;
            }
            
            //contains more than 2 tirets
            var splittedName = name.Split("-");
            if (splittedName.Length > 2)
            {
                return false;
            }
            
            //tiret at first or second pos check
            if (name[1] == '-' || name[2] == '-')
            {
                return false;
            }
            
            //check if no contains not permitted character
            foreach (var namePart in splittedName)
            {
                if (!CharacterManager.NAME_REGEX.IsMatch(namePart))
                {
                    return false;
                }
            }

            //vowel check
            var iC = 0;
            while (iC < (name.Length - 2))
            {
                if (name[iC] == name[iC + 1])
                {
                    if (name[iC] == name[iC + 2])
                    {
                        return false;
                    }
                }
                iC++;
            }


            return true;
        }
    }
}