using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class TitlesAndOrnamentsListMessage : NetworkMessage
    {

	    public int[] titles;
	    public int[] ornaments;
	    public int activeTitle;
	    public int activeOrnament;


        public TitlesAndOrnamentsListMessage()
        {
        }

        public TitlesAndOrnamentsListMessage(int[] titles, int[] ornaments, int activeTitle, int activeOrnament)
        {
            this.titles = titles;
            this.ornaments = ornaments;
            this.activeTitle = activeTitle;
            this.activeOrnament = activeOrnament;

        }
    }
}