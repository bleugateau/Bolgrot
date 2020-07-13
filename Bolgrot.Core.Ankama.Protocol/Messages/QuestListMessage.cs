using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class QuestListMessage : NetworkMessage
    {

	    public int[] finishedQuestsIds;
	    public int[] finishedQuestsCounts;
	    public int[] activeQuests;


        public QuestListMessage()
        {
        }

        public QuestListMessage(int[] finishedQuestsIds, int[] finishedQuestsCounts, int[] activeQuests)
        {
            this.finishedQuestsIds = finishedQuestsIds;
            this.finishedQuestsCounts = finishedQuestsCounts;
            this.activeQuests = activeQuests;

        }
    }
}