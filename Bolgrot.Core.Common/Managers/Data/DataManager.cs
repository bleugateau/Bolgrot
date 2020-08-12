using System;
using System.Collections.Concurrent;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NLog;

namespace Bolgrot.Core.Common.Managers.Data
{

    public interface IDataManager
    {
        void Initialize();
        Task<ConcurrentDictionary<int, object>> GetDataByClassName(string className);
    }
    
    public class DataManager : IDataManager
    {
        private ConcurrentDictionary<string, ConcurrentDictionary<int, object>> _data = new ConcurrentDictionary<string, ConcurrentDictionary<int, object>>();
        private bool _isInitialized = false;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public DataManager()
        {
        }


        /**
         * Initialize the manager
         */
        public void Initialize()
        {
            if (_isInitialized)
            {
                this._logger.Error("DataManager already initialized");
                return;
            }
            
            this.RegisterData();

            this.FillData();

            this._isInitialized = true;
            
            this._logger.Info("DataManager initialized.");
        }
        
        /**
         * Register data key dictionary
         */
        private void RegisterData()
        {
            this._data.TryAdd("Interactives", new ConcurrentDictionary<int, object>());
            this._data.TryAdd("Heads", new ConcurrentDictionary<int, object>());
            this._data.TryAdd("AlignmentGift", new ConcurrentDictionary<int, object>());
            this._data.TryAdd("AchievementCategories", new ConcurrentDictionary<int, object>());
            this._data.TryAdd("AlmanaxCalendars", new ConcurrentDictionary<int, object>());
            this._data.TryAdd("AlignmentSides", new ConcurrentDictionary<int, object>());
            this._data.TryAdd("Npcs", new ConcurrentDictionary<int, object>());
            this._data.TryAdd("AlignmentRankJntGift", new ConcurrentDictionary<int, object>());
            this._data.TryAdd("AlignmentRank", new ConcurrentDictionary<int, object>());
            this._data.TryAdd("Areas", new ConcurrentDictionary<int, object>());
            this._data.TryAdd("BidHouseCategories", new ConcurrentDictionary<int, object>());
            this._data.TryAdd("Breeds", new ConcurrentDictionary<int, object>());
            this._data.TryAdd("ChatChannels", new ConcurrentDictionary<int, object>());
            this._data.TryAdd("Incarnation", new ConcurrentDictionary<int, object>());
            this._data.TryAdd("IncarnationLevels", new ConcurrentDictionary<int, object>());
            this._data.TryAdd("ItemTypes", new ConcurrentDictionary<int, object>());
            this._data.TryAdd("Months", new ConcurrentDictionary<int, object>());
            this._data.TryAdd("MountBehaviors", new ConcurrentDictionary<int, object>());
            this._data.TryAdd("OptionalFeatures", new ConcurrentDictionary<int, object>());
            this._data.TryAdd("QuestObjectiveTypes", new ConcurrentDictionary<int, object>());
            this._data.TryAdd("RankNames", new ConcurrentDictionary<int, object>());
            this._data.TryAdd("ShieldModelsLevels", new ConcurrentDictionary<int, object>());
            this._data.TryAdd("Smileys", new ConcurrentDictionary<int, object>());
            this._data.TryAdd("SpellStates", new ConcurrentDictionary<int, object>());
            this._data.TryAdd("SpellTypes", new ConcurrentDictionary<int, object>());
            this._data.TryAdd("SuperAreas", new ConcurrentDictionary<int, object>());
            this._data.TryAdd("ToaRank", new ConcurrentDictionary<int, object>());
            this._data.TryAdd("TypeActions", new ConcurrentDictionary<int, object>());
            this._data.TryAdd("WorldMaps", new ConcurrentDictionary<int, object>());
            this._data.TryAdd("Spells", new ConcurrentDictionary<int, object>());
            this._data.TryAdd("Items", new ConcurrentDictionary<int, object>());
            this._data.TryAdd("SpellLevels", new ConcurrentDictionary<int, object>());
            this._data.TryAdd("Effects", new ConcurrentDictionary<int, object>());
            this._data.TryAdd("Mounts", new ConcurrentDictionary<int, object>());
            this._data.TryAdd("AlignmentTitles", new ConcurrentDictionary<int, object>());
            this._data.TryAdd("CensoredWords", new ConcurrentDictionary<int, object>());
            this._data.TryAdd("Notifications", new ConcurrentDictionary<int, object>());
            this._data.TryAdd("Servers", new ConcurrentDictionary<int, object>());
            this._data.TryAdd("ServerCommunities", new ConcurrentDictionary<int, object>());
            this._data.TryAdd("ServerPopulations", new ConcurrentDictionary<int, object>());
            this._data.TryAdd("ServerGameTypes", new ConcurrentDictionary<int, object>());
        }



        /**
         * Retrieve and fill game data
         */
        public void FillData()
        {
            foreach (var registeredData in this._data)
            {
                if (!this._data.ContainsKey(registeredData.Key))
                {
                    this._logger.Error($"{registeredData.Key} is not register.");
                    continue;
                }
            
                if (!File.Exists($"datas/map/{registeredData.Key}.json"))
                {
                    this._logger.Error($"{registeredData.Key}.json missed.");
                    continue;
                }
                
                this._data.TryGetValue(registeredData.Key, out ConcurrentDictionary<int, object> data);
                
                StreamReader reader = new StreamReader($"datas/map/{registeredData.Key}.json");

                try
                {
                    string classNameContent = reader.ReadToEnd();
                    var entities = JsonConvert.DeserializeObject<JObject>(!classNameContent.StartsWith("{")
                        ? "{" + classNameContent + "}"
                        : classNameContent);

                    
                    Type entityType = Type.GetType($"Bolgrot.Core.Common.Entity.Data.{registeredData.Key}, Bolgrot.Core.Common", true);

                    foreach (var entity in entities)
                    {
                        data.TryAdd(Convert.ToInt32(entity.Key),
                            JsonConvert.DeserializeObject(entity.Value.ToString(), entityType));
                    }
                    
                    this._logger.Debug($"{data.Count} {entityType.Name} data retrieved.");
                }
                catch (Exception ex)
                {
                    this._logger.Error(ex.Message);
                }

                reader.Close();
            }
        }
        
        /**
         * Retrieve and load game data
         */
        public async Task<ConcurrentDictionary<int, object>> GetDataByClassName(string className)
        {
            if (!this._data.ContainsKey(className))
            {
                //logger
                this._logger.Error($"{className} is not register.");
                return null;
            }
            
            if (!File.Exists($"datas/map/{className}.json"))
            {
                //logger
                this._logger.Error($"{className}.json missed.");
                return null;
            }

            this._data.TryGetValue(className, out ConcurrentDictionary<int, object> data);

            return data;
        }
        
    }
}