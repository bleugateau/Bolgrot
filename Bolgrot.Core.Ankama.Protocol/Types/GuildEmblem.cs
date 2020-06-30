namespace Bolgrot.Core.Ankama.Protocol.Types
{
    public class GuildEmblem
    {

	    public int symbolShape;
	    public int symbolColor;
	    public int backgroundShape;
	    public int backgroundColor;


        public string _type = "GuildEmblem";

        public GuildEmblem()
        {
        }

        public GuildEmblem(int symbolShape, int symbolColor, int backgroundShape, int backgroundColor)
        {
            this.symbolShape = symbolShape;
            this.symbolColor = symbolColor;
            this.backgroundShape = backgroundShape;
            this.backgroundColor = backgroundColor;

        }
    }
}