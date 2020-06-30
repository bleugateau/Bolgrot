namespace Bolgrot.Core.Ankama.Protocol.Types
{
    public class CharacterCharacteristicsInformations
    {

	    public int experience;
	    public int experienceLevelFloor;
	    public int experienceNextLevelFloor;
	    public int kamas;
	    public int statsPoints;
	    public int additionnalPoints;
	    public int spellsPoints;
	    public ActorExtendedAlignmentInformations alignmentInfos;
	    public int lifePoints;
	    public int maxLifePoints;
	    public int energyPoints;
	    public int maxEnergyPoints;
	    public int actionPointsCurrent;
	    public int movementPointsCurrent;
	    public CharacterBaseCharacteristic initiative;
	    public CharacterBaseCharacteristic prospecting;
	    public CharacterBaseCharacteristic actionPoints;
	    public CharacterBaseCharacteristic movementPoints;
	    public CharacterBaseCharacteristic strength;
	    public CharacterBaseCharacteristic vitality;
	    public CharacterBaseCharacteristic wisdom;
	    public CharacterBaseCharacteristic chance;
	    public CharacterBaseCharacteristic agility;
	    public CharacterBaseCharacteristic intelligence;
	    public CharacterBaseCharacteristic range;
	    public CharacterBaseCharacteristic summonableCreaturesBoost;
	    public CharacterBaseCharacteristic summonableMaximumBombs;
	    public CharacterBaseCharacteristic reflect;
	    public CharacterBaseCharacteristic criticalHit;
	    public int criticalHitWeapon;
	    public CharacterBaseCharacteristic criticalMiss;
	    public CharacterBaseCharacteristic healBonus;
	    public CharacterBaseCharacteristic allDamagesBonus;
	    public CharacterBaseCharacteristic weaponDamagesBonusPercent;
	    public CharacterBaseCharacteristic damagesBonusPercent;
	    public CharacterBaseCharacteristic trapBonus;
	    public CharacterBaseCharacteristic trapBonusPercent;
	    public CharacterBaseCharacteristic permanentDamagePercent;
	    public CharacterBaseCharacteristic tackleBlock;
	    public CharacterBaseCharacteristic tackleEvade;
	    public CharacterBaseCharacteristic PAAttack;
	    public CharacterBaseCharacteristic PMAttack;
	    public CharacterBaseCharacteristic pushDamageBonus;
	    public CharacterBaseCharacteristic criticalDamageBonus;
	    public CharacterBaseCharacteristic neutralDamageBonus;
	    public CharacterBaseCharacteristic earthDamageBonus;
	    public CharacterBaseCharacteristic waterDamageBonus;
	    public CharacterBaseCharacteristic airDamageBonus;
	    public CharacterBaseCharacteristic fireDamageBonus;
	    public CharacterBaseCharacteristic dodgePALostProbability;
	    public CharacterBaseCharacteristic dodgePMLostProbability;
	    public CharacterBaseCharacteristic neutralElementResistPercent;
	    public CharacterBaseCharacteristic earthElementResistPercent;
	    public CharacterBaseCharacteristic waterElementResistPercent;
	    public CharacterBaseCharacteristic airElementResistPercent;
	    public CharacterBaseCharacteristic fireElementResistPercent;
	    public CharacterBaseCharacteristic neutralElementReduction;
	    public CharacterBaseCharacteristic earthElementReduction;
	    public CharacterBaseCharacteristic waterElementReduction;
	    public CharacterBaseCharacteristic airElementReduction;
	    public CharacterBaseCharacteristic fireElementReduction;
	    public CharacterBaseCharacteristic pushDamageReduction;
	    public CharacterBaseCharacteristic criticalDamageReduction;
	    public CharacterBaseCharacteristic pvpNeutralElementResistPercent;
	    public CharacterBaseCharacteristic pvpEarthElementResistPercent;
	    public CharacterBaseCharacteristic pvpWaterElementResistPercent;
	    public CharacterBaseCharacteristic pvpAirElementResistPercent;
	    public CharacterBaseCharacteristic pvpFireElementResistPercent;
	    public CharacterBaseCharacteristic pvpNeutralElementReduction;
	    public CharacterBaseCharacteristic pvpEarthElementReduction;
	    public CharacterBaseCharacteristic pvpWaterElementReduction;
	    public CharacterBaseCharacteristic pvpAirElementReduction;
	    public CharacterBaseCharacteristic pvpFireElementReduction;
	    public CharacterBaseCharacteristic dealtDamageMultiplierMelee;
	    public CharacterBaseCharacteristic receivedDamageMultiplierMelee;
	    public CharacterBaseCharacteristic dealtDamageMultiplierDistance;
	    public CharacterBaseCharacteristic receivedDamageMultiplierDistance;
	    public CharacterBaseCharacteristic dealtDamageMultiplierWeapon;
	    public CharacterBaseCharacteristic receivedDamageMultiplierWeapon;
	    public CharacterBaseCharacteristic dealtDamageMultiplierSpells;
	    public CharacterBaseCharacteristic receivedDamageMultiplierSpells;
	    public int[] spellModifications;
	    public int probationTime;


        public string _type = "CharacterCharacteristicsInformations";

        public CharacterCharacteristicsInformations()
        {
        }

        public CharacterCharacteristicsInformations(int experience, int experienceLevelFloor, int experienceNextLevelFloor, int kamas, int statsPoints, int additionnalPoints, int spellsPoints, ActorExtendedAlignmentInformations alignmentInfos, int lifePoints, int maxLifePoints, int energyPoints, int maxEnergyPoints, int actionPointsCurrent, int movementPointsCurrent, CharacterBaseCharacteristic initiative, CharacterBaseCharacteristic prospecting, CharacterBaseCharacteristic actionPoints, CharacterBaseCharacteristic movementPoints, CharacterBaseCharacteristic strength, CharacterBaseCharacteristic vitality, CharacterBaseCharacteristic wisdom, CharacterBaseCharacteristic chance, CharacterBaseCharacteristic agility, CharacterBaseCharacteristic intelligence, CharacterBaseCharacteristic range, CharacterBaseCharacteristic summonableCreaturesBoost, CharacterBaseCharacteristic summonableMaximumBombs, CharacterBaseCharacteristic reflect, CharacterBaseCharacteristic criticalHit, int criticalHitWeapon, CharacterBaseCharacteristic criticalMiss, CharacterBaseCharacteristic healBonus, CharacterBaseCharacteristic allDamagesBonus, CharacterBaseCharacteristic weaponDamagesBonusPercent, CharacterBaseCharacteristic damagesBonusPercent, CharacterBaseCharacteristic trapBonus, CharacterBaseCharacteristic trapBonusPercent, CharacterBaseCharacteristic permanentDamagePercent, CharacterBaseCharacteristic tackleBlock, CharacterBaseCharacteristic tackleEvade, CharacterBaseCharacteristic PAAttack, CharacterBaseCharacteristic PMAttack, CharacterBaseCharacteristic pushDamageBonus, CharacterBaseCharacteristic criticalDamageBonus, CharacterBaseCharacteristic neutralDamageBonus, CharacterBaseCharacteristic earthDamageBonus, CharacterBaseCharacteristic waterDamageBonus, CharacterBaseCharacteristic airDamageBonus, CharacterBaseCharacteristic fireDamageBonus, CharacterBaseCharacteristic dodgePALostProbability, CharacterBaseCharacteristic dodgePMLostProbability, CharacterBaseCharacteristic neutralElementResistPercent, CharacterBaseCharacteristic earthElementResistPercent, CharacterBaseCharacteristic waterElementResistPercent, CharacterBaseCharacteristic airElementResistPercent, CharacterBaseCharacteristic fireElementResistPercent, CharacterBaseCharacteristic neutralElementReduction, CharacterBaseCharacteristic earthElementReduction, CharacterBaseCharacteristic waterElementReduction, CharacterBaseCharacteristic airElementReduction, CharacterBaseCharacteristic fireElementReduction, CharacterBaseCharacteristic pushDamageReduction, CharacterBaseCharacteristic criticalDamageReduction, CharacterBaseCharacteristic pvpNeutralElementResistPercent, CharacterBaseCharacteristic pvpEarthElementResistPercent, CharacterBaseCharacteristic pvpWaterElementResistPercent, CharacterBaseCharacteristic pvpAirElementResistPercent, CharacterBaseCharacteristic pvpFireElementResistPercent, CharacterBaseCharacteristic pvpNeutralElementReduction, CharacterBaseCharacteristic pvpEarthElementReduction, CharacterBaseCharacteristic pvpWaterElementReduction, CharacterBaseCharacteristic pvpAirElementReduction, CharacterBaseCharacteristic pvpFireElementReduction, CharacterBaseCharacteristic dealtDamageMultiplierMelee, CharacterBaseCharacteristic receivedDamageMultiplierMelee, CharacterBaseCharacteristic dealtDamageMultiplierDistance, CharacterBaseCharacteristic receivedDamageMultiplierDistance, CharacterBaseCharacteristic dealtDamageMultiplierWeapon, CharacterBaseCharacteristic receivedDamageMultiplierWeapon, CharacterBaseCharacteristic dealtDamageMultiplierSpells, CharacterBaseCharacteristic receivedDamageMultiplierSpells, int[] spellModifications, int probationTime)
        {
            this.experience = experience;
            this.experienceLevelFloor = experienceLevelFloor;
            this.experienceNextLevelFloor = experienceNextLevelFloor;
            this.kamas = kamas;
            this.statsPoints = statsPoints;
            this.additionnalPoints = additionnalPoints;
            this.spellsPoints = spellsPoints;
            this.alignmentInfos = alignmentInfos;
            this.lifePoints = lifePoints;
            this.maxLifePoints = maxLifePoints;
            this.energyPoints = energyPoints;
            this.maxEnergyPoints = maxEnergyPoints;
            this.actionPointsCurrent = actionPointsCurrent;
            this.movementPointsCurrent = movementPointsCurrent;
            this.initiative = initiative;
            this.prospecting = prospecting;
            this.actionPoints = actionPoints;
            this.movementPoints = movementPoints;
            this.strength = strength;
            this.vitality = vitality;
            this.wisdom = wisdom;
            this.chance = chance;
            this.agility = agility;
            this.intelligence = intelligence;
            this.range = range;
            this.summonableCreaturesBoost = summonableCreaturesBoost;
            this.summonableMaximumBombs = summonableMaximumBombs;
            this.reflect = reflect;
            this.criticalHit = criticalHit;
            this.criticalHitWeapon = criticalHitWeapon;
            this.criticalMiss = criticalMiss;
            this.healBonus = healBonus;
            this.allDamagesBonus = allDamagesBonus;
            this.weaponDamagesBonusPercent = weaponDamagesBonusPercent;
            this.damagesBonusPercent = damagesBonusPercent;
            this.trapBonus = trapBonus;
            this.trapBonusPercent = trapBonusPercent;
            this.permanentDamagePercent = permanentDamagePercent;
            this.tackleBlock = tackleBlock;
            this.tackleEvade = tackleEvade;
            this.PAAttack = PAAttack;
            this.PMAttack = PMAttack;
            this.pushDamageBonus = pushDamageBonus;
            this.criticalDamageBonus = criticalDamageBonus;
            this.neutralDamageBonus = neutralDamageBonus;
            this.earthDamageBonus = earthDamageBonus;
            this.waterDamageBonus = waterDamageBonus;
            this.airDamageBonus = airDamageBonus;
            this.fireDamageBonus = fireDamageBonus;
            this.dodgePALostProbability = dodgePALostProbability;
            this.dodgePMLostProbability = dodgePMLostProbability;
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
            this.pushDamageReduction = pushDamageReduction;
            this.criticalDamageReduction = criticalDamageReduction;
            this.pvpNeutralElementResistPercent = pvpNeutralElementResistPercent;
            this.pvpEarthElementResistPercent = pvpEarthElementResistPercent;
            this.pvpWaterElementResistPercent = pvpWaterElementResistPercent;
            this.pvpAirElementResistPercent = pvpAirElementResistPercent;
            this.pvpFireElementResistPercent = pvpFireElementResistPercent;
            this.pvpNeutralElementReduction = pvpNeutralElementReduction;
            this.pvpEarthElementReduction = pvpEarthElementReduction;
            this.pvpWaterElementReduction = pvpWaterElementReduction;
            this.pvpAirElementReduction = pvpAirElementReduction;
            this.pvpFireElementReduction = pvpFireElementReduction;
            this.dealtDamageMultiplierMelee = dealtDamageMultiplierMelee;
            this.receivedDamageMultiplierMelee = receivedDamageMultiplierMelee;
            this.dealtDamageMultiplierDistance = dealtDamageMultiplierDistance;
            this.receivedDamageMultiplierDistance = receivedDamageMultiplierDistance;
            this.dealtDamageMultiplierWeapon = dealtDamageMultiplierWeapon;
            this.receivedDamageMultiplierWeapon = receivedDamageMultiplierWeapon;
            this.dealtDamageMultiplierSpells = dealtDamageMultiplierSpells;
            this.receivedDamageMultiplierSpells = receivedDamageMultiplierSpells;
            this.spellModifications = spellModifications;
            this.probationTime = probationTime;

        }
    }
}