using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bolgrot.Core.Ankama.Protocol.Types;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class ShortcutBarContentMessage : NetworkMessage
    {

	    public int barType;
	    public Shortcut[] shortcuts;


        public ShortcutBarContentMessage()
        {
        }

        public ShortcutBarContentMessage(int barType, Shortcut[] shortcuts)
        {
            this.barType = barType;
            this.shortcuts = shortcuts;

        }
    }
}