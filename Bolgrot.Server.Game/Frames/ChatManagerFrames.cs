using Autofac;
using Bolgrot.Core.Ankama.Protocol.Messages;
using Bolgrot.Core.Ankama.Protocol.SendMessages;
using Bolgrot.Core.Common.Managers.Frames;
using Bolgrot.Server.Game.Managers;
using Bolgrot.Server.Game.Network;
using NLog;

namespace Bolgrot.Server.Game.Frames
{
    class ChatManagerFrames
    {
        protected readonly Logger _logger = LogManager.GetCurrentClassLogger();
        //0 General
        //1 Team
        //2 Guild
        //3 Alliance 
        //4 Group
        //5 Trade
        //6 Recruiment
        //7 Newbiew
        //8 Administrator
        //9 Private
        //10 Information
        //12 Promotional
        //13 Koliseu
        // Ps: 11 dont exist?!

        [InterceptFrame("ChatClientMultiMessage")]
        public void ChatClientMultiMessageFrame(GameClient client, ChatClientMultiMessage chatClientMultiMessage)
        {
            this._logger.Info($"Char {client.Character.Name} said {chatClientMultiMessage.content} in {chatClientMultiMessage.channel}");
            //client.Send(new FriendsListMessage(new int[] { }));
            if (chatClientMultiMessage.content.StartsWith("."))
            {
               // CommandManager.Instance.GetCommandeFromContent(chatClientMultiMessage.content, client);
            }
            else
            {

                switch (chatClientMultiMessage.channel)//((ChatChannelsMultiEnum)chatClientMultiMessage.channel)
                {
                    case 0://ChatChannelsMultiEnum.CHANNEL_GLOBAL:
                        var map = Container.Instance().Resolve<IMapManager>().GetMapById(client.Character.MapId).Result;
                        if (map == null)
                        {
                            client.Disconnect();
                            break;
                        }
                        foreach (var othersClients in Container.Instance().Resolve<IWorldManager>().GetNearestClientsFromCharacter(client.Character))
                            othersClients.Send(new ChatServerMessage(0, chatClientMultiMessage.content, new int[0],0,"", client.Character.Id, client.Character.Name, client.Character.AccountId));

                        client.Send(new ChatServerMessage(0, chatClientMultiMessage.content, new int[0],0, "", client.Character.Id, client.Character.Name, client.Character.AccountId));
                        break;
                }
            }
        }
        //[InterceptFrame("ChatClientPrivateMessage")]
        //public void ChatClientPrivateMessageFrame(GameClient client, ChatClientPrivateMessage chatClientMultiMessage)
        //{ 
        
        //}
    }
}
