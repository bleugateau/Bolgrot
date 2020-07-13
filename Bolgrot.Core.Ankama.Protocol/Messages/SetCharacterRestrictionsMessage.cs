using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bolgrot.Core.Ankama.Protocol.Types;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class SetCharacterRestrictionsMessage : NetworkMessage
    {

	    public ActorRestrictionsInformations restrictions;


        public SetCharacterRestrictionsMessage()
        {
        }

        public SetCharacterRestrictionsMessage(ActorRestrictionsInformations restrictions)
        {
            this.restrictions = restrictions;

        }
    }
}