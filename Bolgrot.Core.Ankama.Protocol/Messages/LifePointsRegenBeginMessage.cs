using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class LifePointsRegenBeginMessage : NetworkMessage
    {

	    public int regenRate;


        public LifePointsRegenBeginMessage()
        {
        }

        public LifePointsRegenBeginMessage(int regenRate)
        {
            this.regenRate = regenRate;

        }
    }
}