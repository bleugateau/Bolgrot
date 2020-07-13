using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bolgrot.Core.Ankama.Protocol.Types;


namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class AchievementListMessage : NetworkMessage
    {

	    public int[] finishedAchievementsIds;
	    public int[] rewardableAchievements;
	    public AchievementAccount[] accountAchievements;
	    public int[] accountAchievementsRewardable;
	    public object enrichData;


        public AchievementListMessage()
        {
        }

        public AchievementListMessage(int[] finishedAchievementsIds, int[] rewardableAchievements, AchievementAccount[] accountAchievements, int[] accountAchievementsRewardable, object enrichData)
        {
            this.finishedAchievementsIds = finishedAchievementsIds;
            this.rewardableAchievements = rewardableAchievements;
            this.accountAchievements = accountAchievements;
            this.accountAchievementsRewardable = accountAchievementsRewardable;
            this.enrichData = enrichData;

        }
    }
}