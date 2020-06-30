namespace Bolgrot.Core.Ankama.Protocol.Types
{
    public class FightCommonInformations
    {

	    public int fightId;
	    public int fightType;
	    public FightTeamInformations[] fightTeams;
	    public int[] fightTeamsPositions;
	    public FightOptionsInformations[] fightTeamsOptions;


        public string _type = "FightCommonInformations";

        public FightCommonInformations()
        {
        }

        public FightCommonInformations(int fightId, int fightType, FightTeamInformations[] fightTeams, int[] fightTeamsPositions, FightOptionsInformations[] fightTeamsOptions)
        {
            this.fightId = fightId;
            this.fightType = fightType;
            this.fightTeams = fightTeams;
            this.fightTeamsPositions = fightTeamsPositions;
            this.fightTeamsOptions = fightTeamsOptions;

        }
    }
}