using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.SendMessages
{
    public class ChatClientMultiMessage : CallNetworkMessage
    {

	    public string content;
        public int channel;


        public ChatClientMultiMessage()
        {
        }

        public ChatClientMultiMessage(string content,int channel)
        {
            this.content = content;
            this.channel = channel;

        }
    }
}