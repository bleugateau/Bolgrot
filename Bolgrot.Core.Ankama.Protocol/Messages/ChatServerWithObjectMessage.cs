using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bolgrot.Core.Ankama.Protocol.Types;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class ChatServerWithObjectMessage : NetworkMessage
    {

	    public int channel;
	    public string content;
	    public int[] urls;
	    public int timestamp;
	    public string fingerprint;
	    public int senderId;
	    public string senderName;
	    public int senderAccountId;
	    public ObjectItem[] objects;


        public ChatServerWithObjectMessage()
        {
        }

        public ChatServerWithObjectMessage(int channel, string content, int[] urls, int timestamp, string fingerprint, int senderId, string senderName, int senderAccountId, ObjectItem[] objects)
        {
            this.channel = channel;
            this.content = content;
            this.urls = urls;
            this.timestamp = timestamp;
            this.fingerprint = fingerprint;
            this.senderId = senderId;
            this.senderName = senderName;
            this.senderAccountId = senderAccountId;
            this.objects = objects;

        }
    }
}