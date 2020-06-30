namespace Bolgrot.Core.Ankama.Protocol.Types
{
    public class AllianceInformations
    {

	    public int allianceId;
	    public string allianceTag;
	    public string allianceName;
	    public GuildEmblem allianceEmblem;


        public string _type = "AllianceInformations";

        public AllianceInformations()
        {
        }

        public AllianceInformations(int allianceId, string allianceTag, string allianceName, GuildEmblem allianceEmblem)
        {
            this.allianceId = allianceId;
            this.allianceTag = allianceTag;
            this.allianceName = allianceName;
            this.allianceEmblem = allianceEmblem;

        }
    }
}