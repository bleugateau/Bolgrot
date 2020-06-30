namespace Bolgrot.Core.Ankama.Protocol.Types
{
    public class HumanInformations
    {

	    public ActorRestrictionsInformations restrictions;
	    public bool sex;
	    public HumanOptionGuild[] options;


        public string _type = "HumanInformations";

        public HumanInformations()
        {
        }

        public HumanInformations(ActorRestrictionsInformations restrictions, bool sex, HumanOptionGuild[] options)
        {
            this.restrictions = restrictions;
            this.sex = sex;
            this.options = options;

        }
    }
}