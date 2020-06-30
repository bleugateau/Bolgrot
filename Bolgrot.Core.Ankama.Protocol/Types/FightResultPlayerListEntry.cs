namespace Bolgrot.Core.Ankama.Protocol.Types
{
    public class FightResultPlayerListEntry
    {

	    public int outcome;
	    public FightLoot rewards;
	    public int id;
	    public bool alive;
	    public int level;
	    public FightResultExperienceData[] additional;


        public string _type = "FightResultPlayerListEntry";

        public FightResultPlayerListEntry()
        {
        }

        public FightResultPlayerListEntry(int outcome, FightLoot rewards, int id, bool alive, int level, FightResultExperienceData[] additional)
        {
            this.outcome = outcome;
            this.rewards = rewards;
            this.id = id;
            this.alive = alive;
            this.level = level;
            this.additional = additional;

        }
    }
}