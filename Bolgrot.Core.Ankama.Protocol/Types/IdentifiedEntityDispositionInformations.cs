namespace Bolgrot.Core.Ankama.Protocol.Types
{
    public class IdentifiedEntityDispositionInformations
    {

	    public int cellId;
	    public int direction;
	    public int id;


        public string _type = "IdentifiedEntityDispositionInformations";

        public IdentifiedEntityDispositionInformations()
        {
        }

        public IdentifiedEntityDispositionInformations(int cellId, int direction, int id)
        {
            this.cellId = cellId;
            this.direction = direction;
            this.id = id;

        }
    }
}