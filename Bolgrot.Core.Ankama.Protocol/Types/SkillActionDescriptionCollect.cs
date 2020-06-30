namespace Bolgrot.Core.Ankama.Protocol.Types
{
    public class SkillActionDescriptionCollect
    {

	    public int skillId;
	    public int time;
	    public int min;
	    public int max;


        public string _type = "SkillActionDescriptionCollect";

        public SkillActionDescriptionCollect()
        {
        }

        public SkillActionDescriptionCollect(int skillId, int time, int min, int max)
        {
            this.skillId = skillId;
            this.time = time;
            this.min = min;
            this.max = max;

        }
    }
}