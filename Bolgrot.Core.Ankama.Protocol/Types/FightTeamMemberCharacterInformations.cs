namespace Bolgrot.Core.Ankama.Protocol.Types
{
    public class FightTeamMemberCharacterInformations
    {

	    public int id;
	    public string name;
	    public int level;


        public string _type = "FightTeamMemberCharacterInformations";

        public FightTeamMemberCharacterInformations()
        {
        }

        public FightTeamMemberCharacterInformations(int id, string name, int level)
        {
            this.id = id;
            this.name = name;
            this.level = level;

        }
    }
}