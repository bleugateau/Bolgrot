namespace Bolgrot.Core.Ankama.Protocol.Types
{
    public class GameFightMinimalStats
    {

	    public int lifePoints;
	    public int maxLifePoints;
	    public int baseMaxLifePoints;
	    public int permanentDamagePercent;
	    public int shieldPoints;
	    public int actionPoints;
	    public int maxActionPoints;
	    public int movementPoints;
	    public int maxMovementPoints;
	    public int summoner;
	    public bool summoned;
	    public int neutralElementResistPercent;
	    public int earthElementResistPercent;
	    public int waterElementResistPercent;
	    public int airElementResistPercent;
	    public int fireElementResistPercent;
	    public int neutralElementReduction;
	    public int earthElementReduction;
	    public int waterElementReduction;
	    public int airElementReduction;
	    public int fireElementReduction;
	    public int criticalDamageFixedResist;
	    public int pushDamageFixedResist;
	    public int dodgePALostProbability;
	    public int dodgePMLostProbability;
	    public int tackleBlock;
	    public int tackleEvade;
	    public int invisibilityState;


        public string _type = "GameFightMinimalStats";

        public GameFightMinimalStats()
        {
        }

        public GameFightMinimalStats(int lifePoints, int maxLifePoints, int baseMaxLifePoints, int permanentDamagePercent, int shieldPoints, int actionPoints, int maxActionPoints, int movementPoints, int maxMovementPoints, int summoner, bool summoned, int neutralElementResistPercent, int earthElementResistPercent, int waterElementResistPercent, int airElementResistPercent, int fireElementResistPercent, int neutralElementReduction, int earthElementReduction, int waterElementReduction, int airElementReduction, int fireElementReduction, int criticalDamageFixedResist, int pushDamageFixedResist, int dodgePALostProbability, int dodgePMLostProbability, int tackleBlock, int tackleEvade, int invisibilityState)
        {
            this.lifePoints = lifePoints;
            this.maxLifePoints = maxLifePoints;
            this.baseMaxLifePoints = baseMaxLifePoints;
            this.permanentDamagePercent = permanentDamagePercent;
            this.shieldPoints = shieldPoints;
            this.actionPoints = actionPoints;
            this.maxActionPoints = maxActionPoints;
            this.movementPoints = movementPoints;
            this.maxMovementPoints = maxMovementPoints;
            this.summoner = summoner;
            this.summoned = summoned;
            this.neutralElementResistPercent = neutralElementResistPercent;
            this.earthElementResistPercent = earthElementResistPercent;
            this.waterElementResistPercent = waterElementResistPercent;
            this.airElementResistPercent = airElementResistPercent;
            this.fireElementResistPercent = fireElementResistPercent;
            this.neutralElementReduction = neutralElementReduction;
            this.earthElementReduction = earthElementReduction;
            this.waterElementReduction = waterElementReduction;
            this.airElementReduction = airElementReduction;
            this.fireElementReduction = fireElementReduction;
            this.criticalDamageFixedResist = criticalDamageFixedResist;
            this.pushDamageFixedResist = pushDamageFixedResist;
            this.dodgePALostProbability = dodgePALostProbability;
            this.dodgePMLostProbability = dodgePMLostProbability;
            this.tackleBlock = tackleBlock;
            this.tackleEvade = tackleEvade;
            this.invisibilityState = invisibilityState;

        }
    }
}