namespace Bolgrot.Core.Ankama.Protocol.Types
{
    public class FightTriggeredEffect
    {

	    public int uid;
	    public int targetId;
	    public int turnDuration;
	    public int dispelable;
	    public int spellId;
	    public int parentBoostUid;
	    public int param1;
	    public int param2;
	    public int param3;
	    public int delay;


        public string _type = "FightTriggeredEffect";

        public FightTriggeredEffect()
        {
        }

        public FightTriggeredEffect(int uid, int targetId, int turnDuration, int dispelable, int spellId, int parentBoostUid, int param1, int param2, int param3, int delay)
        {
            this.uid = uid;
            this.targetId = targetId;
            this.turnDuration = turnDuration;
            this.dispelable = dispelable;
            this.spellId = spellId;
            this.parentBoostUid = parentBoostUid;
            this.param1 = param1;
            this.param2 = param2;
            this.param3 = param3;
            this.delay = delay;

        }
    }
}