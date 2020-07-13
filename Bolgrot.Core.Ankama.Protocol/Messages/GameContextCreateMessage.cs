using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class GameContextCreateMessage : NetworkMessage
    {

	    public int context;


        public GameContextCreateMessage()
        {
        }

        public GameContextCreateMessage(int context)
        {
            this.context = context;

        }
    }
}