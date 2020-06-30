namespace Bolgrot.Core.Ankama.Protocol.Types
{
    public class ActorRestrictionsInformations
    {

	    public bool cantBeAggressed;
	    public bool cantBeChallenged;
	    public bool cantTrade;
	    public bool cantBeAttackedByMutant;
	    public bool cantRun;
	    public bool forceSlowWalk;
	    public bool cantMinimize;
	    public bool cantMove;
	    public bool cantAggress;
	    public bool cantChallenge;
	    public bool cantExchange;
	    public bool cantAttack;
	    public bool cantChat;
	    public bool cantBeMerchant;
	    public bool cantUseObject;
	    public bool cantUseTaxCollector;
	    public bool cantUseInteractive;
	    public bool cantSpeakToNPC;
	    public bool cantChangeZone;
	    public bool cantAttackMonster;
	    public bool cantWalk8Directions;


        public string _type = "ActorRestrictionsInformations";

        public ActorRestrictionsInformations()
        {
        }

        public ActorRestrictionsInformations(bool cantBeAggressed, bool cantBeChallenged, bool cantTrade, bool cantBeAttackedByMutant, bool cantRun, bool forceSlowWalk, bool cantMinimize, bool cantMove, bool cantAggress, bool cantChallenge, bool cantExchange, bool cantAttack, bool cantChat, bool cantBeMerchant, bool cantUseObject, bool cantUseTaxCollector, bool cantUseInteractive, bool cantSpeakToNPC, bool cantChangeZone, bool cantAttackMonster, bool cantWalk8Directions)
        {
            this.cantBeAggressed = cantBeAggressed;
            this.cantBeChallenged = cantBeChallenged;
            this.cantTrade = cantTrade;
            this.cantBeAttackedByMutant = cantBeAttackedByMutant;
            this.cantRun = cantRun;
            this.forceSlowWalk = forceSlowWalk;
            this.cantMinimize = cantMinimize;
            this.cantMove = cantMove;
            this.cantAggress = cantAggress;
            this.cantChallenge = cantChallenge;
            this.cantExchange = cantExchange;
            this.cantAttack = cantAttack;
            this.cantChat = cantChat;
            this.cantBeMerchant = cantBeMerchant;
            this.cantUseObject = cantUseObject;
            this.cantUseTaxCollector = cantUseTaxCollector;
            this.cantUseInteractive = cantUseInteractive;
            this.cantSpeakToNPC = cantSpeakToNPC;
            this.cantChangeZone = cantChangeZone;
            this.cantAttackMonster = cantAttackMonster;
            this.cantWalk8Directions = cantWalk8Directions;

        }
    }
}