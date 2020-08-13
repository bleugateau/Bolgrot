using System.Collections.Generic;
using System.Linq;
using Autofac;
using Bolgrot.Core.Ankama.Protocol.Messages;
using Bolgrot.Core.Ankama.Protocol.SendMessages;
using Bolgrot.Core.Ankama.Protocol.Types;
using Bolgrot.Core.Common.Managers.Frames;
using Bolgrot.Core.Common.Repository;
using Bolgrot.Server.Game.Managers;
using Bolgrot.Server.Game.Network;

namespace Bolgrot.Server.Game.Frames
{
    public class ApproachFrames
    {
        [InterceptFrame("CharactersListRequestMessage")]
        public void CharactersListRequestMessageFrame(GameClient client,
            CharactersListRequestMessage charactersListRequestMessage)
        {
            ApproachFrames.SendCharactersListMessage(client);
        }
        
        [InterceptFrame("CharacterCreationRequestMessage")]
        public void CharacterCreationRequestMessageFrame(GameClient client, CharacterCreationRequestMessage characterCreationRequestMessage)
        {
            Container.Instance().Resolve<ICharacterManager>().CreateCharacter(client, characterCreationRequestMessage);
        }

        [InterceptFrame("CharacterDeletionRequestMessage")]
        public void CharacterDeletionRequestMessageFrame(GameClient client, CharacterDeletionRequestMessage characterDeletionRequestMessage)
        {
            Container.Instance().Resolve<ICharacterManager>().CharacterDeletion(client, characterDeletionRequestMessage);
        }


        [InterceptFrame("CharacterSelectionMessage")]
        public void CharacterSelectionMessageFrame(GameClient client,
            CharacterSelectionMessage characterSelectionMessage)
        {
            //@TODO
            
        }

        /**
         * Send CharactersListMessage from GameClient
         */
        public static void SendCharactersListMessage(GameClient client)
        {
            var characters = Container.Instance().Resolve<ICharacterRepository>().Entities().Values.Where(x => x.AccountId == 1 && !x.IsDeleted);
            List<CharacterBaseInformations> characterBaseInformations = new List<CharacterBaseInformations>();

            foreach (var character in characters)
            {
                characterBaseInformations.Add(new CharacterBaseInformations(character.Id, character.Level, character.Name, character.EntityLook, character.Breed, character.Sex));
            }
            
            
            client.Send(new CharactersListMessage(false, characterBaseInformations.ToArray()));
        }
    }
}