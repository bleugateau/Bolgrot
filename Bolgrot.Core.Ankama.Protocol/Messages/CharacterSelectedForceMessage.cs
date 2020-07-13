using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class CharacterSelectedForceMessage : NetworkMessage
    {

	    public int id;


        public CharacterSelectedForceMessage()
        {
        }

        public CharacterSelectedForceMessage(int id)
        {
            this.id = id;

        }
    }
}