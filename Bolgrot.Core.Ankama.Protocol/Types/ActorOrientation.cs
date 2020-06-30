namespace Bolgrot.Core.Ankama.Protocol.Types
{
    public class ActorOrientation
    {

	    public int id;
	    public int direction;


        public string _type = "ActorOrientation";

        public ActorOrientation()
        {
        }

        public ActorOrientation(int id, int direction)
        {
            this.id = id;
            this.direction = direction;

        }
    }
}