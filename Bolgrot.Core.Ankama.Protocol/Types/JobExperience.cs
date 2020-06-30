namespace Bolgrot.Core.Ankama.Protocol.Types
{
    public class JobExperience
    {

	    public int jobId;
	    public int jobLevel;
	    public int jobXP;
	    public int jobXpLevelFloor;
	    public int jobXpNextLevelFloor;


        public string _type = "JobExperience";

        public JobExperience()
        {
        }

        public JobExperience(int jobId, int jobLevel, int jobXP, int jobXpLevelFloor, int jobXpNextLevelFloor)
        {
            this.jobId = jobId;
            this.jobLevel = jobLevel;
            this.jobXP = jobXP;
            this.jobXpLevelFloor = jobXpLevelFloor;
            this.jobXpNextLevelFloor = jobXpNextLevelFloor;

        }
    }
}