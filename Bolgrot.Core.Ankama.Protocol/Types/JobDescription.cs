namespace Bolgrot.Core.Ankama.Protocol.Types
{
    public class JobDescription
    {

	    public int jobId;
	    public SkillActionDescriptionCollect[] skills;


        public string _type = "JobDescription";

        public JobDescription()
        {
        }

        public JobDescription(int jobId, SkillActionDescriptionCollect[] skills)
        {
            this.jobId = jobId;
            this.skills = skills;

        }
    }
}