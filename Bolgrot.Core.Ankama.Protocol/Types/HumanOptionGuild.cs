namespace Bolgrot.Core.Ankama.Protocol.Types
{
    public class HumanOptionGuild
    {
        public GuildInformations guildInformations { get; set; }


        public string _type = "HumanOptionGuild";


        public HumanOptionGuild()
        {

        }

        public HumanOptionGuild(GuildInformations guildInformations)
        {
            this.guildInformations = guildInformations;
        }
    }
}
