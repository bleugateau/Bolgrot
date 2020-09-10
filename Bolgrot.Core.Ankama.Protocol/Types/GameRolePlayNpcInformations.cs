using Bolgrot.Core.Ankama.Protocol.Data;
using Newtonsoft.Json;

namespace Bolgrot.Core.Ankama.Protocol.Types
{
    public class GameRolePlayNpcInformations : GameRolePlayInformations
    {

        public int contextualId;
        public EntityLook look;
        public EntityDispositionInformations disposition;
        public long npcId;
        public bool sex;
        public long specialArtworkId;
        [JsonProperty("_npcData")]
        public Npcs npcData;
        
        


        public string _type = "GameRolePlayNpcInformations";

        public GameRolePlayNpcInformations()
        {
        }

        public GameRolePlayNpcInformations(int contextualId, EntityLook look, EntityDispositionInformations disposition, long npcId, bool sex, long specialArtworkId, Npcs npcData)
        {
            this.contextualId = contextualId;
            this.look = look;
            this.disposition = disposition;
            this.npcId = npcId;
            this.sex = sex;
            this.specialArtworkId = specialArtworkId;
            this.npcData = npcData;
        }
    }
    
    public class NpcData
    {
        [JsonProperty("_type")]
        public string Type { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("nameId")]
        public string NameId { get; set; }

        [JsonProperty("dialogMessages")]
        public long[][] DialogMessages { get; set; }

        [JsonProperty("dialogReplies")]
        public long[][] DialogReplies { get; set; }

        [JsonProperty("actions")]
        public long[] Actions { get; set; }

        [JsonProperty("gender")]
        public long Gender { get; set; }

        [JsonProperty("look")]
        public string Look { get; set; }

        [JsonProperty("animFunList")]
        public object[] AnimFunList { get; set; }

        [JsonProperty("actionsName")]
        public string[] ActionsName { get; set; }
    }
}