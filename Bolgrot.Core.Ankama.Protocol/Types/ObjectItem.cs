namespace Bolgrot.Core.Ankama.Protocol.Types
{
    public class ObjectItem
    {

	    public int position;
	    public int objectGID;
	    public ObjectEffectInteger[] effects;
	    public int objectUID;
	    public int quantity;


        public string _type = "ObjectItem";

        public ObjectItem()
        {
        }

        public ObjectItem(int position, int objectGID, ObjectEffectInteger[] effects, int objectUID, int quantity)
        {
            this.position = position;
            this.objectGID = objectGID;
            this.effects = effects;
            this.objectUID = objectUID;
            this.quantity = quantity;

        }
    }
}