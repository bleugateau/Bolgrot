using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace Bolgrot.Core.Ankama.Protocol
{
    public abstract class CallNetworkMessage
    {
        public string type => this.GetType().UnderlyingSystemType.Name;

        public object buildMessage()
        {
            var builtMessage = new ExpandoObject() as IDictionary<string, Object>;
            var dataObj = new ExpandoObject() as IDictionary<string, Object>;

            foreach (var field in this.GetType().GetProperties().Where(x => x.Name != "type" && x.Name != "data"))
            {
                dataObj.Add(field.Name.ToString(), field.GetValue(this));
            }

            builtMessage.Add("type", this.type);
            builtMessage.Add("data", dataObj);



            return builtMessage;
        }
    }
}