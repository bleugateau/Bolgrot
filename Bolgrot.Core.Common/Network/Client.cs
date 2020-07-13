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
        
        public ConcurrentDictionary<long, string> MessagesQueues { get; }

        private long InstanceId = 0;
        

        public Client(string contextId)
        {
            this.ContextId = contextId;
            this.MessagesQueues = new ConcurrentDictionary<long, string>();
        }

        public void Send(NetworkMessage message)
        {
            
            this.MessagesQueues.TryAdd(InstanceId, $"4{JsonConvert.SerializeObject(message)}");
            InstanceId++;
        }
    }
}