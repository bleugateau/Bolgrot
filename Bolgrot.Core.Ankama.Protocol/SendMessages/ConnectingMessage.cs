namespace Bolgrot.Core.Ankama.Protocol.SendMessages
{
    public class ConnectingMessage
    {
        public string language { get; set; }
        public string[] server { get; set; }
        //public string client { get; set; }
        //public string appVersion { get; set; }
        //public string buildVersion { get; set; }

        public ConnectingMessage(string language, string[] server/*, string client, string appVersion, string buildVersion*/)
        {
            this.language = language;
            this.server = server;
            //this.client = client;
            //this.appVersion = appVersion;
            //this.buildVersion = buildVersion;
        }
    }
}