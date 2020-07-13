using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class EnabledChannelsMessage : NetworkMessage
    {

	    public int[] channels;
	    public int[] disallowed;


        public EnabledChannelsMessage()
        {
        }

        public EnabledChannelsMessage(int[] channels, int[] disallowed)
        {
            this.channels = channels;
            this.disallowed = disallowed;

        }
    }
}