namespace Bolgrot.Core.Ankama.Protocol.Types
{
    public class SpellItem
    {

	    public int position;
	    public int spellId;
	    public int spellLevel;


        public string _type = "SpellItem";

        public SpellItem()
        {
        }

        public SpellItem(int position, int spellId, int spellLevel)
        {
            this.position = position;
            this.spellId = spellId;
            this.spellLevel = spellLevel;

        }
    }
}