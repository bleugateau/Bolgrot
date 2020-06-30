namespace Bolgrot.Core.Ankama.Protocol.Types
{
    public class GameFightCharacterInformations
    {

	    public int contextualId;
	    public EntityLook look;
	    public FightEntityDispositionInformations disposition;
	    public int teamId;
	    public bool alive;
	    public GameFightMinimalStatsPreparation stats;
	    public string name;
	    public PlayerStatus status;
	    public int level;
	    public ActorAlignmentInformations alignmentInfos;
	    public int breed;

        public string _type = "GameFightCharacterInformations";

        public GameFightCharacterInformations()
        {
        }

        public GameFightCharacterInformations(int contextualId, EntityLook look, FightEntityDispositionInformations disposition, int teamId, bool alive, GameFightMinimalStatsPreparation stats, string name, PlayerStatus status, int level, ActorAlignmentInformations alignmentInfos, int breed)
        {
            this.contextualId = contextualId;
            this.look = look;
            this.disposition = disposition;
            this.teamId = teamId;
            this.alive = alive;
            this.stats = stats;
            this.name = name;
            this.status = status;
            this.level = level;
            this.alignmentInfos = alignmentInfos;
            this.breed = breed;

        }
    }
}