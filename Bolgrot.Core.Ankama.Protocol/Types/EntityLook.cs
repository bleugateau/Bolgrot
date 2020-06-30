namespace Bolgrot.Core.Ankama.Protocol.Types
{
    public class EntityLook
    {

	    public int bonesId;
	    public int[] skins;
	    public int[] indexedColors;
	    public int[] scales;
	    public SubEntity[] subentities;


        public string _type = "EntityLook";

        public EntityLook()
        {
        }

        public EntityLook(int bonesId, int[] skins, int[] indexedColors, int[] scales, SubEntity[] subentities)
        {
            this.bonesId = bonesId;
            this.skins = skins;
            this.indexedColors = indexedColors;
            this.scales = scales;
            this.subentities = subentities;

        }
    }
}