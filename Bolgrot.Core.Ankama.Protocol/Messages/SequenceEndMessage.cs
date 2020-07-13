using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class SequenceEndMessage : NetworkMessage
    {

	    public int actionId;
	    public int authorId;
	    public int sequenceType;


        public SequenceEndMessage()
        {
        }

        public SequenceEndMessage(int actionId, int authorId, int sequenceType)
        {
            this.actionId = actionId;
            this.authorId = authorId;
            this.sequenceType = sequenceType;

        }
    }
}