namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class ProtocolRequired : NetworkMessage
    {

        public int requiredVersion;
        public int currentVersion;

        public ProtocolRequired()
        {
        }

        public ProtocolRequired(int requiredVersion, int currentVersion)
        {
            this.requiredVersion = requiredVersion;
            this.currentVersion = currentVersion;
        }
    }
}