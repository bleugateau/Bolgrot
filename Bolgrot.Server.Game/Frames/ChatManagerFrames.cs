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

        [InterceptFrame("ChatClientMultiMessage")]
        public void ChatClientMultiMessageFrame(GameClient client, ChatClientMultiMessage chatClientMultiMessage)
        {
            //chatClientMultiMessage
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
                            //return;
                            break;
                        }
                        foreach (var othersClients in Container.Instance().Resolve<IWorldManager>().GetNearestClientsFromCharacter(client.Character))
                            othersClients.Send(new ChatServerMessage(0, chatClientMultiMessage.content, new int[0],0,"", client.Character.Id, client.Character.Name, client.Character.AccountId));

                        client.Send(new ChatServerMessage(0, chatClientMultiMessage.content, new int[0],0, "", client.Character.Id, client.Character.Name, client.Character.AccountId));
                        break;
                    //case ChatChannelsMultiEnum.CHANNEL_GUILD:
                    //    if (client.ActiveCharacter.Guild != null)
                    //    {
                    //        foreach (var othersClient in WorldManager.Instance.worldClients.FindAll(x => x.ActiveCharacter != null && x.ActiveCharacter.Id != client.ActiveCharacter.Id && x.ActiveCharacter.Guild.Id == client.ActiveCharacter.Guild.Id))
                    //            othersClient.SendPacket(new ChatServerMessage((uint)ChatChannelsMultiEnum.CHANNEL_GUILD, chatClientMultiMessage.content, 0, client.ActiveCharacter.Name, client.ActiveCharacter.Id, client.ActiveCharacter.Name, "", (uint)client.Account.Id));

                    //        client.SendPacket(new ChatServerMessage((uint)ChatChannelsMultiEnum.CHANNEL_GUILD, chatClientMultiMessage.content, 0, client.ActiveCharacter.Name, client.ActiveCharacter.Id, client.ActiveCharacter.Name, "", (uint)client.Account.Id));
                    //    }
                    //    else
                    //        client.SendPacket(new ChatErrorMessage((uint)ChatErrorEnum.CHAT_ERROR_NO_GUILD));
                    //    break;
                }
            }
        }
    }
}
