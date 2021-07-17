using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Autofac;
using Bolgrot.Core.Ankama.Protocol.Messages;
using Bolgrot.Core.Ankama.Protocol.SendMessages;
using Bolgrot.Core.Ankama.Protocol.Types;
using Bolgrot.Core.Common.Entity;
using Bolgrot.Core.Common.Managers.Frames;
using Bolgrot.Core.Common.Network;
using Bolgrot.Core.Common.Repository;
using Bolgrot.Server.Game.Managers;
using Bolgrot.Server.Game.Network;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NLog;

namespace Bolgrot.Server.Game.Frames
{
    public class AuthenticationFrames
    {
        protected readonly Logger _logger = LogManager.GetCurrentClassLogger();
        static HttpClient clientweb = new HttpClient();

        private IAccountRepository _accountRepository = null;
        [InterceptCall("connecting")]
        public void ConnectingCallFrame(Client client, JObject message)
        {
            client.Send(new ProtocolRequired(1594, 1594));
            client.Send(new HelloGameMessage());
        }
        [InterceptCall("reconnecting")]
        public void ReConnectingCallFrame(Client client, JObject message)
        {
            //client.Send(new CredentialsAcknowledgementMessage());
            client.Send(new sessionReconnected());
            client.Disconnect();
            //Container.Instance().Resolve<IWorldManager>().GetNearestClientsFromCharacter(null);
        }
        

        [InterceptFrame("BasicPingMessage")]
        public void BasicPingMessageFrame(GameClient client, BasicPingMessage basicPingMessage)
        {
            client.Send(new BasicPongMessage(false));
        }

        [InterceptFrame("AuthenticationTicketMessage")]
        public async void AuthenticationTicketMessageFrame(Client client, AuthenticationTicketMessage authenticationTicketMessage)
        {

            //verif du compte via IPC
            Account account = null;
            //HttpResponseMessage response = await clientweb.GetAsync("http://localhost:3000/ticket/get?secure_key=secret_key&ticket=" + authenticationTicketMessage.ticket);
            HttpResponseMessage response = await clientweb.GetAsync("http://localhost:3000/ticket/get?secure_key=secret_key&ticket=" + authenticationTicketMessage.ticket);

            if (response.IsSuccessStatusCode)
            {
                var account_json = await response.Content.ReadAsStringAsync();
                account = JsonConvert.DeserializeObject<Account>(account_json);
            }
            //var account = await Container.Instance().Resolve<IAuthenticationManager>().GetAccountByTicket(authenticationTicketMessage.ticket);
            if (account == null)
            {
                client.Send(new AuthenticationTicketRefusedMessage());
                return;
                //while (account == null)
                //{
                //    account = await Container.Instance().Resolve<IAuthenticationManager>().GetAccountByTicket(authenticationTicketMessage.ticket);
                //}
            }
            client.Account = account;
            this._logger.Info($"'{client.Account.Login}' switched to world with Ticket={authenticationTicketMessage.ticket}");            
            client.Send(new AuthenticationTicketAcceptedMessage());
            client.Send(new BasicTimeMessage(1606023934, 60));// time which yet it
            client.Send(new ServerSettingsMessage("fr",0,0));
            client.Send(new ServerOptionalFeaturesMessage(new int[] { 1,2,3,5}));
            client.Send(new ServerSessionConstantsMessage(new ServerSessionConstantInteger[] { new ServerSessionConstantInteger(1,1500000), new ServerSessionConstantInteger(2, 7200000), new ServerSessionConstantInteger(3, 30), new ServerSessionConstantInteger(4, 86400000), new ServerSessionConstantInteger(5, 60000) }));          
            client.Send(new AccountCapabilitiesMessage(client.Account.Id, true, 32767, 32767, 0, new int[] {}, new object()));
            client.Send(new TrustStatusMessage(true));
            client.Language = authenticationTicketMessage.lang;
        }
    }
}