using System;
using System.Collections;
using System.Threading.Tasks;
using Bolgrot.Core.Common.Entity;
using Bolgrot.Core.Common.Repository;
using Bolgrot.Server.Auth.Proxy.Enums;
using Bolgrot.Server.Auth.Proxy.Requests;
using Bolgrot.Server.Auth.Proxy.Response;
using Newtonsoft.Json;

namespace Bolgrot.Server.Auth.Managers
{

    public interface IWorldServerManager
    {
        public System.Collections.Generic.ICollection<WorldServer> Servers();
    }

    public class WorldServerManager : IWorldServerManager
    {
        private IWorldServerRepository _worldRepository = null;
        private readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();
        private System.Collections.Generic.ICollection<WorldServer> WorldServers { get; set; }

        public WorldServerManager(IWorldServerRepository worldRepository)
        {
            _worldRepository = worldRepository;
            WorldServers = this._worldRepository.Entities().Values;
        }


        public System.Collections.Generic.ICollection<WorldServer> Servers()
        {
            return WorldServers;
        }
    }
}

