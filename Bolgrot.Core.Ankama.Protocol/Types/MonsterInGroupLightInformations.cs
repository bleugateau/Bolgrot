namespace Bolgrot.Core.Ankama.Protocol.Types
{
    public class MonsterInGroupLightInformations
    {

	    public int creatureGenericId;
	    public int grade;


        public string _type = "MonsterInGroupLightInformations";

        public MonsterInGroupLightInformations()
        {
        }

        public MonsterInGroupLightInformations(int creatureGenericId, int grade)
        {
            this.creatureGenericId = creatureGenericId;
            this.grade = grade;

        }
    }
}