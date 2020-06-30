namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class HelloConnectMessage : NetworkMessage
    {
        public string salt;
        public int[] key;

        public HelloConnectMessage()
        {
        }

        public HelloConnectMessage(string salt, int[] key)
        {
            this.salt = salt;
            this.key = key;
        }
    }
}