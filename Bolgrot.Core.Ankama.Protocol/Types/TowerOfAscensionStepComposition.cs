namespace Bolgrot.Core.Ankama.Protocol.Types
{
    public class TowerOfAscensionStepComposition
    {

	    public int stepNumber;
	    public TowerOfAscensionStageComposition[] stages;


        public string _type = "TowerOfAscensionStepComposition";

        public TowerOfAscensionStepComposition()
        {
        }

        public TowerOfAscensionStepComposition(int stepNumber, TowerOfAscensionStageComposition[] stages)
        {
            this.stepNumber = stepNumber;
            this.stages = stages;

        }
    }
}