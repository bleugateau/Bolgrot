using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class AlignmentRankUpdateMessage : NetworkMessage
    {

	    public int alignmentRank;
	    public bool verbose;


        public AlignmentRankUpdateMessage()
        {
        }

        public AlignmentRankUpdateMessage(int alignmentRank, bool verbose)
        {
            this.alignmentRank = alignmentRank;
            this.verbose = verbose;

        }
    }
}