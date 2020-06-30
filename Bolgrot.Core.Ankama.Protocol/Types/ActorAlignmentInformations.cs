namespace Bolgrot.Core.Ankama.Protocol.Types
{
    public class ActorAlignmentInformations
    {

	    public int alignmentSide;
	    public int alignmentValue;
	    public int alignmentGrade;
	    public int characterPower;


        public string _type = "ActorAlignmentInformations";

        public ActorAlignmentInformations()
        {
        }

        public ActorAlignmentInformations(int alignmentSide, int alignmentValue, int alignmentGrade, int characterPower)
        {
            this.alignmentSide = alignmentSide;
            this.alignmentValue = alignmentValue;
            this.alignmentGrade = alignmentGrade;
            this.characterPower = characterPower;

        }
    }
}