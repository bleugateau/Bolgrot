using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bolgrot.Core.Ankama.Protocol;
using Bolgrot.Core.Common.Entity;
using EmbedIO.WebSockets;
using Newtonsoft.Json;

namespace Bolgrot.Core.Common.Network
{
    public class Client
    {
        public string ContextId { get; }
        
        public IWebSocketContext Context {get;}
        
        public Account Account { get; set; }
        
        public ConcurrentDictionary<long, string> MessagesQueues { get; }

        public event EventHandler<EventArgs> OnDisconnect;
        
        private long InstanceId = 0;
        

        public Client(string contextId, IWebSocketContext context)
        {
            this.ContextId = contextId;
            this.Context = context;
            this.MessagesQueues = new ConcurrentDictionary<long, string>();
        }

        public void Send(NetworkMessage message)
        {
            this.MessagesQueues.TryAdd(InstanceId, $"4{JsonConvert.SerializeObject(message)}");
            InstanceId++;
        }

        public void Disconnect()
        {
            this.OnDisconnect(this, EventArgs.Empty);
        }
    }
}