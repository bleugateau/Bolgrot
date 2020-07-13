using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class ServerSettingsMessage : NetworkMessage
    {

	    public string lang;
	    public int community;
	    public int gameType;


        public ServerSettingsMessage()
        {
        }

        public ServerSettingsMessage(string lang, int community, int gameType)
        {
            this.lang = lang;
            this.community = community;
            this.gameType = gameType;

        }
    }
}