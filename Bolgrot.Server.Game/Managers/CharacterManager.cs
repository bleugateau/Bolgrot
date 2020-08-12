using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using Bolgrot.Core.Common.Entity.Data;
using Bolgrot.Core.Common.Repository;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NLog;

namespace Bolgrot.Server.Game.Managers
{
    public interface ICharacterManager
    {
        public Dictionary<int, Heads> HeadsData { get; }
        public Dictionary<int, Breeds> BreedsData { get; }
    }

    public class CharacterManager : AbstractGameManager, ICharacterManager
    {
        public Dictionary<int, Heads> HeadsData { get; }
        public Dictionary<int, Breeds> BreedsData { get; }
        
        private ICharacterRepository _characterRepository;

        public CharacterManager(ICharacterRepository characterRepository)
        {
            this._characterRepository = characterRepository;

            this._logger.Info("CharacterManager loading...");
            
            this.LoadGameData<Heads>(this.HeadsData);
            this.LoadGameData<Breeds>(this.BreedsData);
        }
    }
}