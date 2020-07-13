using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class ChallengeResultMessage : NetworkMessage
    {

	    public int challengeId;
	    public bool success;


        public ChallengeResultMessage()
        {
        }

        public ChallengeResultMessage(int challengeId, bool success)
        {
            this.challengeId = challengeId;
            this.success = success;

        }
    }
}