namespace Bolgrot.Core.Ankama.Protocol
{
    public abstract class NetworkMessage
    {
        public string _messageType => this.GetType().UnderlyingSystemType.Name;

        public bool _isInitialized => true;
    }
}