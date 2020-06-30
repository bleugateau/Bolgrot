namespace Bolgrot.Core.Ankama.Protocol.Types
{
    public class FightLoot
    {

	    public int[] objects;
	    public int kamas;


        public string _type = "FightLoot";

        public FightLoot()
        {
        }

        public FightLoot(int[] objects, int kamas)
        {
            this.objects = objects;
            this.kamas = kamas;

        }
    }
}