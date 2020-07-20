namespace Bolgrot.Core.Ankama.Protocol.SendMessages
{
    public class LoginMessage
    {
        public string username { get; set; }

        public string token { get; set; }

        public string salt { get; set; }

        public int[] key { get; set; }

        public LoginMessage(string username, string token, string salt, int[] key)
        {
            this.username = username;
            this.token = token;
            this.salt = salt;
            this.key = key;
        }
    }
}