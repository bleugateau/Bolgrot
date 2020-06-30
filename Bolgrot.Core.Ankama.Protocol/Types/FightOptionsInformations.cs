namespace Bolgrot.Core.Ankama.Protocol.Types
{
    public class FightOptionsInformations
    {

	    public bool isSecret;
	    public bool isRestrictedToPartyOnly;
	    public bool isClosed;
	    public bool isAskingForHelp;


        public string _type = "FightOptionsInformations";

        public FightOptionsInformations()
        {
        }

        public FightOptionsInformations(bool isSecret, bool isRestrictedToPartyOnly, bool isClosed, bool isAskingForHelp)
        {
            this.isSecret = isSecret;
            this.isRestrictedToPartyOnly = isRestrictedToPartyOnly;
            this.isClosed = isClosed;
            this.isAskingForHelp = isAskingForHelp;

        }
    }
}