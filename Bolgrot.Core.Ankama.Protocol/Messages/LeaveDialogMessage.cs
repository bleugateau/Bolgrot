using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class LeaveDialogMessage : NetworkMessage
    {

	    public int dialogType;


        public LeaveDialogMessage()
        {
        }

        public LeaveDialogMessage(int dialogType)
        {
            this.dialogType = dialogType;

        }
    }
}