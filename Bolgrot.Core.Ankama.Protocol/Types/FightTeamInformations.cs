namespace Bolgrot.Core.Ankama.Protocol.Types
{
    public class FightTeamInformations
    {

	    public int teamId;
	    public int leaderId;
	    public int teamSide;
	    public int teamTypeId;
	    public FightTeamMemberCharacterInformations[] teamMembers;


        public string _type = "FightTeamInformations";

        public FightTeamInformations()
        {
        }

        public FightTeamInformations(int teamId, int leaderId, int teamSide, int teamTypeId, FightTeamMemberCharacterInformations[] teamMembers)
        {
            this.teamId = teamId;
            this.leaderId = leaderId;
            this.teamSide = teamSide;
            this.teamTypeId = teamTypeId;
            this.teamMembers = teamMembers;

        }
    }
}