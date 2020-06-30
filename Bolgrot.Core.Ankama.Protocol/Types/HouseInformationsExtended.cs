namespace Bolgrot.Core.Ankama.Protocol.Types
{
    public class HouseInformationsExtended
    {

	    public int houseId;
	    public int[] doorsOnMap;
	    public string ownerName;
	    public bool isOnSale;
	    public bool isSaleLocked;
	    public int modelId;
	    public GuildInformations guildInfo;
	    public string _name;


        public string _type = "HouseInformationsExtended";

        public HouseInformationsExtended()
        {
        }

        public HouseInformationsExtended(int houseId, int[] doorsOnMap, string ownerName, bool isOnSale, bool isSaleLocked, int modelId, GuildInformations guildInfo, string _name)
        {
            this.houseId = houseId;
            this.doorsOnMap = doorsOnMap;
            this.ownerName = ownerName;
            this.isOnSale = isOnSale;
            this.isSaleLocked = isSaleLocked;
            this.modelId = modelId;
            this.guildInfo = guildInfo;
            this._name = _name;

        }
    }
}