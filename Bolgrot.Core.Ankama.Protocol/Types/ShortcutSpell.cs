namespace Bolgrot.Core.Ankama.Protocol.Types
{
    public class ShortcutSpell
    {

	    public int slot;
	    public int spellId;


        public string _type = "ShortcutSpell";

        public ShortcutSpell()
        {
        }

        public ShortcutSpell(int slot, int spellId)
        {
            this.slot = slot;
            this.spellId = spellId;

        }
    }
}