using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Bolgrot.Core.Ankama.Protocol.Enums;
using Bolgrot.Core.Ankama.Protocol.Messages;
using Bolgrot.Core.Ankama.Protocol.SendMessages;
using Bolgrot.Core.Ankama.Protocol.Types;
using Bolgrot.Core.Common.Entity;
using Bolgrot.Core.Common.Entity.Data;
using Bolgrot.Core.Common.Repository;
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
    }

    public class CharacterManager : AbstractGameManager, ICharacterManager
    {
        public Dictionary<int, Heads> HeadsData { get; }
        public Dictionary<int, Breeds> BreedsData { get; }
        
        private ICharacterRepository _characterRepository;

        public CharacterManager(ICharacterRepository characterRepository)
        {
            this._characterRepository = characterRepository;

            this._logger.Info("CharacterManager loading...");
            
            this.HeadsData = this.LoadGameData<Heads>();
            this.BreedsData = this.LoadGameData<Breeds>();
        }

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
            if (Convert.ToBoolean(head.Gender) != characterCreationRequestMessage.sex ||
                head.Breed != characterCreationRequestMessage.breed)
            {
                client.Send(new CharacterCreationResultMessage((int)CharacterCreationResultEnum.ERR_NOT_ALLOWED));
                return null;
            }

            var character = new Character();
            character.Id = this.GenerateId();
            character.AccountId = 1;
            character.Breed = characterCreationRequestMessage.breed;
            character.Sex = characterCreationRequestMessage.sex;
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
            
            character.IsNew = true;
            
            this._characterRepository.Entities().TryAdd(character.Id, character);

            client.Send(new CharacterCreationResultMessage((int)CharacterCreationResultEnum.OK));

            return Task.CompletedTask;
        }
    }
}