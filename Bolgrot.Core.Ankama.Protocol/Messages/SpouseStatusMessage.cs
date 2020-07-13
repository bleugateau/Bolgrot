using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class SpouseStatusMessage : NetworkMessage
    {

	    public bool hasSpouse;


        public SpouseStatusMessage()
        {
        }

        public SpouseStatusMessage(bool hasSpouse)
        {
            this.hasSpouse = hasSpouse;

        }
    }
}