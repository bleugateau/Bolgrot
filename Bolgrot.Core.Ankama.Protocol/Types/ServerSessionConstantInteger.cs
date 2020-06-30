namespace Bolgrot.Core.Ankama.Protocol.Types
{
    public class ServerSessionConstantInteger
    {

	    public int id;
	    public int value;


        public string _type = "ServerSessionConstantInteger";

        public ServerSessionConstantInteger()
        {
        }

        public ServerSessionConstantInteger(int id, int value)
        {
            this.id = id;
            this.value = value;

        }
    }
}