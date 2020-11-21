using System.Collections.Generic;
using System.Linq;
using Autofac;
using Bolgrot.Core.Ankama.Protocol.Messages;
using Bolgrot.Core.Ankama.Protocol.SendMessages;
using Bolgrot.Core.Ankama.Protocol.Types;
using Bolgrot.Core.Common.Managers.Frames;
using Bolgrot.Core.Common.Network;
using Bolgrot.Core.Common.Repository;
using Bolgrot.Server.Game.Managers;
using Bolgrot.Server.Game.Network;
using Newtonsoft.Json.Linq;
using NLog;

namespace Bolgrot.Server.Game.Frames
{
    public class AuthenticationFrames
    {
        protected readonly Logger _logger = LogManager.GetCurrentClassLogger();

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
            var account = await Container.Instance().Resolve<IAuthenticationManager>().GetAccountByTicket(authenticationTicketMessage.ticket);
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
            client.Send(new AccountCapabilitiesMessage(141748286, true, 32767, 32767, 0, new int[] {}, new object()));
            client.Send(new TrustStatusMessage(true));
            client.Language = authenticationTicketMessage.lang;
        }
    }
}