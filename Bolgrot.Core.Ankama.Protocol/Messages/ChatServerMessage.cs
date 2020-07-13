using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class ChatServerMessage : NetworkMessage
    {

	    public int channel;
	    public string content;
	    public int[] urls;
	    public int timestamp;
	    public string fingerprint;
	    public int senderId;
	    public string senderName;
	    public int senderAccountId;


        public ChatServerMessage()
        {
        }

        public ChatServerMessage(int channel, string content, int[] urls, int timestamp, string fingerprint, int senderId, string senderName, int senderAccountId)
        {
            this.channel = channel;
            this.content = content;
            this.urls = urls;
            this.timestamp = timestamp;
            this.fingerprint = fingerprint;
            this.senderId = senderId;
            this.senderName = senderName;
            this.senderAccountId = senderAccountId;

        }
    }
}