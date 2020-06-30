namespace Bolgrot.Core.Ankama.Protocol.Types
{
    public class TowerOfAscensionStageComposition
    {

	    public int stageLevel;
	    public int[] challengeId;
	    public MonsterInGroupLightInformations[] monsters;
	    public int[] _challengePts;


        public string _type = "TowerOfAscensionStageComposition";

        public TowerOfAscensionStageComposition()
        {
        }

        public TowerOfAscensionStageComposition(int stageLevel, int[] challengeId, MonsterInGroupLightInformations[] monsters, int[] _challengePts)
        {
            this.stageLevel = stageLevel;
            this.challengeId = challengeId;
            this.monsters = monsters;
            this._challengePts = _challengePts;

        }
    }
}