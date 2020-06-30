namespace Bolgrot.Core.Ankama.Protocol.Types
{
    public class GameRolePlayCharacterInformations
    {

	    public int contextualId;
	    public EntityLook look;
	    public EntityDispositionInformations disposition;
	    public string name;
	    public HumanInformations humanoidInfo;
	    public int accountId;
	    public ActorAlignmentInformations alignmentInfos;


        public string _type = "GameRolePlayCharacterInformations";

        public GameRolePlayCharacterInformations()
        {
        }

        public GameRolePlayCharacterInformations(int contextualId, EntityLook look, EntityDispositionInformations disposition, string name, HumanInformations humanoidInfo, int accountId, ActorAlignmentInformations alignmentInfos)
        {
            this.contextualId = contextualId;
            this.look = look;
            this.disposition = disposition;
            this.name = name;
            this.humanoidInfo = humanoidInfo;
            this.accountId = accountId;
            this.alignmentInfos = alignmentInfos;

        }
    }
}