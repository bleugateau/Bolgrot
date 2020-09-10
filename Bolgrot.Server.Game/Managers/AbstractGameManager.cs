using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NLog;
using ServiceStack;

namespace Bolgrot.Server.Game.Managers
{
    public abstract class AbstractGameManager
    {
        protected readonly Logger _logger = LogManager.GetCurrentClassLogger();
        
        /**
         * Load game data from json file
         */
        protected Dictionary<int, T> LoadGameData<T>( string jsonName = "")
        {
            //init dictionary
            Dictionary<int, T> gameData = new Dictionary<int, T>();
            
            if (jsonName.IsEmpty())
            {
                jsonName = typeof(T).Name;
            }
            
            StreamReader reader = new StreamReader($"data/{jsonName}.json");

            try
            {
                var headsEntities = JsonConvert.DeserializeObject<JObject>(reader.ReadToEnd());


                foreach (var entity in headsEntities)
                {
                    gameData.TryAdd(Convert.ToInt32(entity.Key),
                        JsonConvert.DeserializeObject<T>(entity.Value.ToString()));
                }


                this._logger.Debug($"{gameData.Count} {jsonName.ToLower()} loaded !");
            }
            catch (Exception ex)
            {
                this._logger.Error(ex.Message);
            }


            reader.Dispose();

            return gameData;
        }
    }
}