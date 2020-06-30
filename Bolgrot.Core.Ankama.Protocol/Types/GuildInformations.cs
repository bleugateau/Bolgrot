namespace Bolgrot.Core.Ankama.Protocol.Types
{
    public class GuildInformations
    {

	    public int guildId;
	    public string guildName;
	    public GuildEmblem guildEmblem;


        public string _type = "GuildInformations";

        public GuildInformations()
        {
        }

        public GuildInformations(int guildId, string guildName, GuildEmblem guildEmblem)
        {
            this.guildId = guildId;
            this.guildName = guildName;
            this.guildEmblem = guildEmblem;

        }
    }
}