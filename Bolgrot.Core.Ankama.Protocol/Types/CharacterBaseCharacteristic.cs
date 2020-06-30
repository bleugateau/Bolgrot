using Newtonsoft.Json;

namespace Bolgrot.Core.Ankama.Protocol.Types
{
    public class CharacterBaseCharacteristic
    {

        [JsonProperty("base")]
	    public int Base;
	    public int additionnal;
	    public int objectsAndMountBonus;
	    public int alignGiftBonus;
	    public int contextModif;


        public string _type = "CharacterBaseCharacteristic";

        public CharacterBaseCharacteristic()
        {
        }

        public CharacterBaseCharacteristic(int Base, int additionnal, int objectsAndMountBonus, int alignGiftBonus, int contextModif)
        {
            this.Base = Base;
            this.additionnal = additionnal;
            this.objectsAndMountBonus = objectsAndMountBonus;
            this.alignGiftBonus = alignGiftBonus;
            this.contextModif = contextModif;

        }
    }
}