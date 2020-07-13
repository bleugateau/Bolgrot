using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.SendMessages
{
    public class CharacterDeletionRequestMessage : CallNetworkMessage
    {

	    public int characterId;
	    public string secretAnswerHash;


        public CharacterDeletionRequestMessage()
        {
        }

        public CharacterDeletionRequestMessage(int characterId, string secretAnswerHash)
        {
            this.characterId = characterId;
            this.secretAnswerHash = secretAnswerHash;

        }
    }
}