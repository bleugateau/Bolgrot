using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class ProtocolRequired : NetworkMessage
    {

	    public int requiredVersion;
	    public int currentVersion;


        public ProtocolRequired()
        {
        }

        public ProtocolRequired(int requiredVersion, int currentVersion)
        {
            this.requiredVersion = requiredVersion;
            this.currentVersion = currentVersion;

        }
    }
}