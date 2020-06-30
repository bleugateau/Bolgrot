namespace Bolgrot.Core.Ankama.Protocol.Types
{
    public class ObjectEffectInteger
    {

	    public int actionId;
	    public int value;


        public string _type = "ObjectEffectInteger";

        public ObjectEffectInteger()
        {
        }

        public ObjectEffectInteger(int actionId, int value)
        {
            this.actionId = actionId;
            this.value = value;

        }
    }
}