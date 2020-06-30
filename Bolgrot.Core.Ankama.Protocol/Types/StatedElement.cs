namespace Bolgrot.Core.Ankama.Protocol.Types
{
    public class StatedElement
    {

	    public int elementId;
	    public int elementCellId;
	    public int elementState;


        public string _type = "StatedElement";

        public StatedElement()
        {
        }

        public StatedElement(int elementId, int elementCellId, int elementState)
        {
            this.elementId = elementId;
            this.elementCellId = elementCellId;
            this.elementState = elementState;

        }
    }
}