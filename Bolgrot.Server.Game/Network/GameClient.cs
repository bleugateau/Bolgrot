using Bolgrot.Core.Common.Entity;
using Bolgrot.Core.Common.Network;
using EmbedIO.WebSockets;

namespace Bolgrot.Server.Game.Network
{
    public class GameClient : Client
    {
        public Character Character { get; set; }
        
        public GameClient(string contextId, IWebSocketContext context) : base(contextId, context)
        {
        }
    }
}