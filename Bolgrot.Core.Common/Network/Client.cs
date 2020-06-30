using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bolgrot.Core.Ankama.Protocol;
using Newtonsoft.Json;

namespace Bolgrot.Core.Common.Network
{
    public class Client
    {
        public string ContextId { get; }
        
        public ConcurrentDictionary<string, string> MessagesQueues { get; set; }

        public Client(string contextId)
        {
            this.ContextId = contextId;
            this.MessagesQueues = new ConcurrentDictionary<string, string>();
        }

        public void Send(NetworkMessage message)
        {
            this.MessagesQueues.TryAdd(message._messageType, $"4{JsonConvert.SerializeObject(message)}");
        }
    }
}