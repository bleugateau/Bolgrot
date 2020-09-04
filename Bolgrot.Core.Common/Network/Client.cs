using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Bolgrot.Core.Ankama.Protocol;
using Bolgrot.Core.Common.Entity;
using Bolgrot.Core.Common.Network.Events;
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
        public event EventHandler<SendMessageEventArgs> SendMessage;
        
        private long InstanceId = 0;
        private Timer _primusPingTimer;
        
        

        public Client(string contextId, IWebSocketContext context)
        {
            this.ContextId = contextId;
            this.Context = context;
            this.MessagesQueues = new ConcurrentDictionary<long, string>();
            
            //fix
            this._primusPingTimer = new Timer(this.PrimusPing, new AutoResetEvent(false), 5000, 25000);
        }

        private void PrimusPing(object? state)
        {
            // this.MessagesQueues.TryAdd(InstanceId, "4\"primus::ping::"+ DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() +"\"");
            // InstanceId++;
            
            SendMessageEventArgs eventArgs = new SendMessageEventArgs();
            eventArgs.message = "4\"primus::ping::"+ DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() +"\"";
            this.SendMessage(this, eventArgs);
        }

        public void Send(NetworkMessage message)
        {
            // this.MessagesQueues.TryAdd(InstanceId, $"4{JsonConvert.SerializeObject(message)}");
            // InstanceId++;
            
            
            SendMessageEventArgs eventArgs = new SendMessageEventArgs();
            eventArgs.message = $"4{JsonConvert.SerializeObject(message)}";
            this.SendMessage(this, eventArgs);
        }

        public void Disconnect()
        {
            this.OnDisconnect(this, EventArgs.Empty);

            this._primusPingTimer.Dispose();
        }
    }
}