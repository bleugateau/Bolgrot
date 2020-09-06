using Newtonsoft.Json;

namespace Bolgrot.Core.Ankama.Protocol.Data
{
    public class SpellLevels
    {
        [JsonProperty("_type")]
        public string Type { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("spellId")]
        public long SpellId { get; set; }

        [JsonProperty("spellBreed")]
        public long SpellBreed { get; set; }

        [JsonProperty("apCost")]
        public long ApCost { get; set; }

        [JsonProperty("minRange")]
        public long MinRange { get; set; }

        [JsonProperty("range")]
        public long Range { get; set; }

        [JsonProperty("castInLine")]
        public bool CastInLine { get; set; }

        [JsonProperty("castInDiagonal")]
        public bool CastInDiagonal { get; set; }

        [JsonProperty("castTestLos")]
        public bool CastTestLos { get; set; }

        [JsonProperty("criticalHitProbability")]
        public long CriticalHitProbability { get; set; }

        [JsonProperty("criticalFailureProbability")]
        public long CriticalFailureProbability { get; set; }

        [JsonProperty("needFreeCell")]
        public bool NeedFreeCell { get; set; }

        [JsonProperty("needTakenCell")]
        public bool NeedTakenCell { get; set; }

        [JsonProperty("needFreeTrapCell")]
        public bool NeedFreeTrapCell { get; set; }

        [JsonProperty("rangeCanBeBoosted")]
        public bool RangeCanBeBoosted { get; set; }

        [JsonProperty("maxStack")]
        public long MaxStack { get; set; }

        [JsonProperty("maxCastPerTurn")]
        public long MaxCastPerTurn { get; set; }

        [JsonProperty("maxCastPerTarget")]
        public long MaxCastPerTarget { get; set; }

        [JsonProperty("minCastInterval")]
        public long MinCastInterval { get; set; }

        [JsonProperty("initialCooldown")]
        public long InitialCooldown { get; set; }

        [JsonProperty("globalCooldown")]
        public long GlobalCooldown { get; set; }

        [JsonProperty("minPlayerLevel")]
        public long MinPlayerLevel { get; set; }

        [JsonProperty("criticalFailureEndsTurn")]
        public bool CriticalFailureEndsTurn { get; set; }

        [JsonProperty("hideEffects")]
        public bool HideEffects { get; set; }

        [JsonProperty("hidden")]
        public bool Hidden { get; set; }

        [JsonProperty("statesRequired")]
        public object[] StatesRequired { get; set; }

        [JsonProperty("statesForbidden")]
        public object[] StatesForbidden { get; set; }

        [JsonProperty("effects")]
        public Effect[] Effects { get; set; }

        [JsonProperty("criticalEffect")]
        public Effect[] CriticalEffect { get; set; }

        [JsonProperty("canSummon")]
        public bool CanSummon { get; set; }

        [JsonProperty("canBomb")]
        public bool CanBomb { get; set; }
    }
    
    public class Effect
    {
        [JsonProperty("_type")]
        public string Type { get; set; }

        [JsonProperty("targetMask")]
        public string TargetMask { get; set; }

        [JsonProperty("duration")]
        public long Duration { get; set; }

        [JsonProperty("diceNum")]
        public long DiceNum { get; set; }

        [JsonProperty("random")]
        public long Random { get; set; }

        [JsonProperty("effectId")]
        public long EffectId { get; set; }

        [JsonProperty("diceSide")]
        public long DiceSide { get; set; }

        [JsonProperty("targetId")]
        public long TargetId { get; set; }

        [JsonProperty("hidden")]
        public bool Hidden { get; set; }

        [JsonProperty("rawZone")]
        public string RawZone { get; set; }

        [JsonProperty("value")]
        public long Value { get; set; }

        [JsonProperty("group")]
        public long Group { get; set; }
    }
}