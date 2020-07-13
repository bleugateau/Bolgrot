using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class UpdateTimedBuffTimeMessage : NetworkMessage
    {

	    public int updatedTime;
	    public int buffType;


        public UpdateTimedBuffTimeMessage()
        {
        }

        public UpdateTimedBuffTimeMessage(int updatedTime, int buffType)
        {
            this.updatedTime = updatedTime;
            this.buffType = buffType;

        }
    }
}