namespace Bolgrot.Core.Ankama.Protocol.Types
{
    public class PlayerStatus
    {

	    public int statusId;


        public string _type = "PlayerStatus";

        public PlayerStatus()
        {
        }

        public PlayerStatus(int statusId)
        {
            this.statusId = statusId;

        }
    }
}