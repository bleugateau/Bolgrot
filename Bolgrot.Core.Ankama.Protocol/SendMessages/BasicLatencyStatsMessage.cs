using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.SendMessages
{
    public class BasicLatencyStatsMessage : CallNetworkMessage
    {

	    public int latency;
	    public int sampleCount;
	    public int max;


        public BasicLatencyStatsMessage()
        {
        }

        public BasicLatencyStatsMessage(int latency, int sampleCount, int max)
        {
            this.latency = latency;
            this.sampleCount = sampleCount;
            this.max = max;

        }
    }
}