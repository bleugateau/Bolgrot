namespace Bolgrot.Core.Ankama.Protocol.Types
{
    public class InteractiveElementSkill
    {

	    public int skillId;
	    public int skillInstanceUid;
	    public int _cursor;
	    public string _name;
	    public int _parentJobId;
	    public int _levelMin;
	    public string _parentJobName;


        public string _type = "InteractiveElementSkill";

        public InteractiveElementSkill()
        {
        }

        public InteractiveElementSkill(int skillId, int skillInstanceUid, int _cursor, string _name, int _parentJobId, int _levelMin, string _parentJobName)
        {
            this.skillId = skillId;
            this.skillInstanceUid = skillInstanceUid;
            this._cursor = _cursor;
            this._name = _name;
            this._parentJobId = _parentJobId;
            this._levelMin = _levelMin;
            this._parentJobName = _parentJobName;

        }
    }
}