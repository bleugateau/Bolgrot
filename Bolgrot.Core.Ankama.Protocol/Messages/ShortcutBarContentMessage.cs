using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class ShortcutBarContentMessage : NetworkMessage
    {

	    public int barType;
	    public int[] shortcuts;


        public ShortcutBarContentMessage()
        {
        }

        public ShortcutBarContentMessage(int barType, int[] shortcuts)
        {
            this.barType = barType;
            this.shortcuts = shortcuts;

        }
    }
}