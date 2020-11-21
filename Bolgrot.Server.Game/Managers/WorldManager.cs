using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Autofac;
using Bolgrot.Core.Common.Entity;
using Bolgrot.Core.Common.Network;
using Bolgrot.Server.Game.Network;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NLog;
using ServiceStack;

namespace Bolgrot.Server.Game.Managers
{
    public interface IWorldManager
    {
        public List<GameClient> GetNearestClientsFromCharacter(Character character);
        public void TryaddClients(string _context, Client _client);
        public void TryremoveClients(string _context);
    }
    public /*abstract*/ class WorldManager : AbstractGameManager, IWorldManager
    {
        public ConcurrentDictionary<string, Client> Clients { get; set; }
        public WorldManager()
        {

        }
        public void Initialize()
        {
            this.Clients = new ConcurrentDictionary<string, Client>();
            //todo
        }
        public List<GameClient> GetNearestClientsFromCharacter(Character character)
        {
            if (character == null)
                return null;

            var clients = Clients.Values.ToList<Client>();
            //return clients.Where(z => z is GameClient).Select(w => w as GameClient).ToList<GameClient>();
            return clients.Where(z => z is GameClient).Select(w => w as GameClient).Where(x => x.Character != null && x.Character.Id != character.Id && x.Character.MapId == character.MapId).ToList<GameClient>();
        }
        public void TryaddClients(string _context,Client _client)
        {
            Clients.TryAdd(_context, _client);
        }
        public void TryremoveClients(string _context)
        {
            Clients.TryRemove(_context, out Client removedClient);
        }

    }
}