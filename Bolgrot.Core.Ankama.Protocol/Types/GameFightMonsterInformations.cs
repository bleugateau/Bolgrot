namespace Bolgrot.Core.Ankama.Protocol.Types
{
    public class GameFightMonsterInformations
    {

	    public int contextualId;
	    public EntityLook look;
	    public FightEntityDispositionInformations disposition;
	    public int teamId;
	    public bool alive;
	    public GameFightMinimalStats stats;
	    public int creatureGenericId;
	    public int creatureGrade;
	    public int monsterLevel;


        public string _type = "GameFightMonsterInformations";

        public GameFightMonsterInformations()
        {
        }

        public GameFightMonsterInformations(int contextualId, EntityLook look, FightEntityDispositionInformations disposition, int teamId, bool alive, GameFightMinimalStats stats, int creatureGenericId, int creatureGrade, int monsterLevel)
        {
            this.contextualId = contextualId;
            this.look = look;
            this.disposition = disposition;
            this.teamId = teamId;
            this.alive = alive;
            this.stats = stats;
            this.creatureGenericId = creatureGenericId;
            this.creatureGrade = creatureGrade;
            this.monsterLevel = monsterLevel;

        }
    }
}