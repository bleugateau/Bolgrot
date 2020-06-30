namespace Bolgrot.Core.Ankama.Protocol.Types
{
    public class FightEntityDispositionInformations
    {

	    public int cellId;
	    public int direction;
	    public int carryingCharacterId;


        public string _type = "FightEntityDispositionInformations";

        public FightEntityDispositionInformations()
        {
        }

        public FightEntityDispositionInformations(int cellId, int direction, int carryingCharacterId)
        {
            this.cellId = cellId;
            this.direction = direction;
            this.carryingCharacterId = carryingCharacterId;

        }
    }
}