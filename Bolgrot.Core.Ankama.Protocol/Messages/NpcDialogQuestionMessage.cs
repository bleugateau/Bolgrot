using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class NpcDialogQuestionMessage : NetworkMessage
    {

	    public int messageId;
	    public int[] dialogParams;
	    public int[] visibleReplies;


        public NpcDialogQuestionMessage()
        {
        }

        public NpcDialogQuestionMessage(int messageId, int[] dialogParams, int[] visibleReplies)
        {
            this.messageId = messageId;
            this.dialogParams = dialogParams;
            this.visibleReplies = visibleReplies;

        }
    }
}