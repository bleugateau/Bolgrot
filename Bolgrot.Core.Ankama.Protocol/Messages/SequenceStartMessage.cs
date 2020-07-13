using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class SequenceStartMessage : NetworkMessage
    {

	    public int sequenceType;
	    public int authorId;


        public SequenceStartMessage()
        {
        }

        public SequenceStartMessage(int sequenceType, int authorId)
        {
            this.sequenceType = sequenceType;
            this.authorId = authorId;

        }
    }
}