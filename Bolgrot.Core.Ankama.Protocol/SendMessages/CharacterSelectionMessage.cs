using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.SendMessages
{
    public class CharacterSelectionMessage : CallNetworkMessage
    {

	    public int id;


        public CharacterSelectionMessage()
        {
        }

        public CharacterSelectionMessage(int id)
        {
            this.id = id;

        }
    }
}