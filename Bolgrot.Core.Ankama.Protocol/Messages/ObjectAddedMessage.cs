using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bolgrot.Core.Ankama.Protocol.Types;
using Newtonsoft.Json;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class ObjectAddedMessage : NetworkMessage
    {

        [JsonProperty("object")]
	    public ObjectItem @object;


        public ObjectAddedMessage()
        {
        }

        public ObjectAddedMessage(ObjectItem @object)
        {
            this.@object = @object;

        }
    }
}