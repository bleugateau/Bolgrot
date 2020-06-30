namespace Bolgrot.Core.Ankama.Protocol.Types
{
    public class GameServerInformations
    {

	    public int id;
	    public int status;
	    public int completion;
	    public bool isSelectable;
	    public int charactersCount;
	    public double date;
	    public string _name;
	    public int _gameTypeId;


        public string _type = "GameServerInformations";

        public GameServerInformations()
        {
        }

        public GameServerInformations(int id, int status, int completion, bool isSelectable, int charactersCount, double date, string _name, int _gameTypeId)
        {
            this.id = id;
            this.status = status;
            this.completion = completion;
            this.isSelectable = isSelectable;
            this.charactersCount = charactersCount;
            this.date = date;
            this._name = _name;
            this._gameTypeId = _gameTypeId;

        }
    }
}