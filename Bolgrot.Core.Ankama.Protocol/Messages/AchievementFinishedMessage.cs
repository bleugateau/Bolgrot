using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class AchievementFinishedMessage : NetworkMessage
    {

	    public int id;
	    public int finishedlevel;
	    public bool isFirstForAccount;
	    public object enrichData;


        public AchievementFinishedMessage()
        {
        }

        public AchievementFinishedMessage(int id, int finishedlevel, bool isFirstForAccount, object enrichData)
        {
            this.id = id;
            this.finishedlevel = finishedlevel;
            this.isFirstForAccount = isFirstForAccount;
            this.enrichData = enrichData;

        }
    }
}