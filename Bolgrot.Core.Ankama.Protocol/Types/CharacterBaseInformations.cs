namespace Bolgrot.Core.Ankama.Protocol.Types
{
    public class CharacterBaseInformations
    {

	    public int id;
	    public int level;
	    public string name;
	    public EntityLook entityLook;
	    public int breed;
	    public bool sex;


        public string _type = "CharacterBaseInformations";

        public CharacterBaseInformations()
        {
        }

        public CharacterBaseInformations(int id, int level, string name, EntityLook entityLook, int breed, bool sex)
        {
            this.id = id;
            this.level = level;
            this.name = name;
            this.entityLook = entityLook;
            this.breed = breed;
            this.sex = sex;

        }
    }
}