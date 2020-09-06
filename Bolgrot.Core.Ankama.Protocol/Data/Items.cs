using Newtonsoft.Json;

namespace Bolgrot.Core.Ankama.Protocol.Data
{
    public class Items
    {
        [JsonProperty("_type")]
        public string Type { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("nameId")]
        public string NameId { get; set; }

        [JsonProperty("typeId")]
        public long TypeId { get; set; }

        [JsonProperty("descriptionId")]
        public string DescriptionId { get; set; }

        [JsonProperty("iconId")]
        public long IconId { get; set; }

        [JsonProperty("level")]
        public long Level { get; set; }

        [JsonProperty("realWeight")]
        public long RealWeight { get; set; }

        [JsonProperty("cursed")]
        public bool Cursed { get; set; }

        [JsonProperty("useAnimationId")]
        public long UseAnimationId { get; set; }

        [JsonProperty("usable")]
        public bool Usable { get; set; }

        [JsonProperty("targetable")]
        public bool Targetable { get; set; }

        [JsonProperty("exchangeable")]
        public bool Exchangeable { get; set; }

        [JsonProperty("price")]
        public long Price { get; set; }

        [JsonProperty("twoHanded")]
        public bool TwoHanded { get; set; }

        [JsonProperty("etheral")]
        public bool Etheral { get; set; }

        [JsonProperty("itemSetId")]
        public long ItemSetId { get; set; }

        [JsonProperty("shieldModelId")]
        public long ShieldModelId { get; set; }

        [JsonProperty("shieldBonuses")]
        public object[] ShieldBonuses { get; set; }

        [JsonProperty("criteria")]
        public string Criteria { get; set; }

        [JsonProperty("criteriaTarget")]
        public string CriteriaTarget { get; set; }

        [JsonProperty("hideEffects")]
        public bool HideEffects { get; set; }

        [JsonProperty("enhanceable")]
        public bool Enhanceable { get; set; }

        [JsonProperty("nonUsableOnAnother")]
        public bool NonUsableOnAnother { get; set; }

        [JsonProperty("appearanceId")]
        public long AppearanceId { get; set; }

        [JsonProperty("secretRecipe")]
        public bool SecretRecipe { get; set; }

        [JsonProperty("recipeSlots")]
        public long RecipeSlots { get; set; }

        [JsonProperty("recipeIds")]
        public object[] RecipeIds { get; set; }

        [JsonProperty("dropMonsterIds")]
        public object[] DropMonsterIds { get; set; }

        [JsonProperty("bonusIsSecret")]
        public bool BonusIsSecret { get; set; }

        [JsonProperty("possibleEffects")]
        public PossibleEffect[] PossibleEffects { get; set; }

        [JsonProperty("favoriteSubAreas")]
        public object[] FavoriteSubAreas { get; set; }

        [JsonProperty("favoriteSubAreasBonus")]
        public long FavoriteSubAreasBonus { get; set; }
    }
    
    
    public class PossibleEffect
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