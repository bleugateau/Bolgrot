namespace Bolgrot.Core.Ankama.Protocol.Types
{
    public class ActorExtendedAlignmentInformations
    {

	    public int alignmentSide;
	    public int alignmentValue;
	    public int alignmentGrade;
	    public int characterPower;
	    public int honor;
	    public int honorGradeFloor;
	    public int honorNextGradeFloor;
	    public int aggressable;


        public string _type = "ActorExtendedAlignmentInformations";

        public ActorExtendedAlignmentInformations()
        {
        }

        public ActorExtendedAlignmentInformations(int alignmentSide, int alignmentValue, int alignmentGrade, int characterPower, int honor, int honorGradeFloor, int honorNextGradeFloor, int aggressable)
        {
            this.alignmentSide = alignmentSide;
            this.alignmentValue = alignmentValue;
            this.alignmentGrade = alignmentGrade;
            this.characterPower = characterPower;
            this.honor = honor;
            this.honorGradeFloor = honorGradeFloor;
            this.honorNextGradeFloor = honorNextGradeFloor;
            this.aggressable = aggressable;

        }
    }
}