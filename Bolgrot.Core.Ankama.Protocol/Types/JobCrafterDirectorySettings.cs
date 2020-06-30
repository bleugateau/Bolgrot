namespace Bolgrot.Core.Ankama.Protocol.Types
{
    public class JobCrafterDirectorySettings
    {

	    public int jobId;
	    public int minSlot;
	    public int userDefinedParams;


        public string _type = "JobCrafterDirectorySettings";

        public JobCrafterDirectorySettings()
        {
        }

        public JobCrafterDirectorySettings(int jobId, int minSlot, int userDefinedParams)
        {
            this.jobId = jobId;
            this.minSlot = minSlot;
            this.userDefinedParams = userDefinedParams;

        }
    }
}