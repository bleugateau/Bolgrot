using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class TextInformationMessage : NetworkMessage
    {

	    public int msgType;
	    public int msgId;
	    public int[] parameters;
	    public string text;


        public TextInformationMessage()
        {
        }

        public TextInformationMessage(int msgType, int msgId, int[] parameters, string text)
        {
            this.msgType = msgType;
            this.msgId = msgId;
            this.parameters = parameters;
            this.text = text;

        }
    }
}