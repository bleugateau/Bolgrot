using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class CharacterNameSuggestionSuccessMessage : NetworkMessage
    {

	    public string suggestion;


        public CharacterNameSuggestionSuccessMessage()
        {
        }

        public CharacterNameSuggestionSuccessMessage(string suggestion)
        {
            this.suggestion = suggestion;

        }
    }
}