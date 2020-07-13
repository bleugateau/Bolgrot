using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class FriendsListMessage : NetworkMessage
    {

	    public int[] friendsList;


        public FriendsListMessage()
        {
        }

        public FriendsListMessage(int[] friendsList)
        {
            this.friendsList = friendsList;

        }
    }
}