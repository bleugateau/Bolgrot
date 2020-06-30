namespace Bolgrot.Core.Ankama.Protocol.Types
{
    public class EntityDispositionInformations
    {

	    public int cellId;
	    public int direction;


        public string _type = "EntityDispositionInformations";

        public EntityDispositionInformations()
        {
        }

        public EntityDispositionInformations(int cellId, int direction)
        {
            this.cellId = cellId;
            this.direction = direction;

        }
    }
}