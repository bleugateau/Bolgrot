namespace Bolgrot.Core.Ankama.Protocol.Types
{
    public class InteractiveElement
    {

	    public int elementId;
	    public int elementTypeId;
	    public InteractiveElementSkill[] enabledSkills;
	    public InteractiveElementSkill[] disabledSkills;
	    public string _name;

        public int ageBonus;


        public string _type = "InteractiveElement";

        public InteractiveElement()
        {
        }

        public InteractiveElement(int elementId, int elementTypeId, InteractiveElementSkill[] enabledSkills, InteractiveElementSkill[] disabledSkills, string _name)
        {
            this.elementId = elementId;
            this.elementTypeId = elementTypeId;
            this.enabledSkills = enabledSkills;
            this.disabledSkills = disabledSkills;
            this._name = _name;

        }
    }

}