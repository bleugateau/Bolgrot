namespace Bolgrot.Core.Ankama.Protocol.Types
{
    public class AlliancePrismInformation
    {

	    public int typeId;
	    public int state;
	    public int nextVulnerabilityDate;
	    public int placementDate;
	    public AllianceInformations alliance;


        public string _type = "AlliancePrismInformation";

        public AlliancePrismInformation()
        {
        }

        public AlliancePrismInformation(int typeId, int state, int nextVulnerabilityDate, int placementDate, AllianceInformations alliance)
        {
            this.typeId = typeId;
            this.state = state;
            this.nextVulnerabilityDate = nextVulnerabilityDate;
            this.placementDate = placementDate;
            this.alliance = alliance;

        }
    }
}