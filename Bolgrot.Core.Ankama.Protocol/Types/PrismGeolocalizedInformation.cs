namespace Bolgrot.Core.Ankama.Protocol.Types
{
    public class PrismGeolocalizedInformation
    {

	    public int subAreaId;
	    public int allianceId;
	    public int worldX;
	    public int worldY;
	    public int mapId;
	    public AlliancePrismInformation prism;
	    public object enrichData;


        public string _type = "PrismGeolocalizedInformation";

        public PrismGeolocalizedInformation()
        {
        }

        public PrismGeolocalizedInformation(int subAreaId, int allianceId, int worldX, int worldY, int mapId, AlliancePrismInformation prism, object enrichData)
        {
            this.subAreaId = subAreaId;
            this.allianceId = allianceId;
            this.worldX = worldX;
            this.worldY = worldY;
            this.mapId = mapId;
            this.prism = prism;
            this.enrichData = enrichData;

        }
    }
}