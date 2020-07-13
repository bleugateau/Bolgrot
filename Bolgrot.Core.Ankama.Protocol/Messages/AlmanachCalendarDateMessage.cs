using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class AlmanachCalendarDateMessage : NetworkMessage
    {

	    public int date;
	    public string _merydeName;


        public AlmanachCalendarDateMessage()
        {
        }

        public AlmanachCalendarDateMessage(int date, string _merydeName)
        {
            this.date = date;
            this._merydeName = _merydeName;

        }
    }
}