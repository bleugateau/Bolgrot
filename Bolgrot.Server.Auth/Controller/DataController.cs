using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Bolgrot.Core.Common.Managers;
using Bolgrot.Core.Common.Managers.Data;
using Bolgrot.Server.Auth.Proxy.Requests;
using EmbedIO;
using EmbedIO.Routing;
using EmbedIO.WebApi;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bolgrot.Server.Auth.Controller
{
    public class DataController : WebApiController
    {
        [Route(HttpVerbs.Post, "/data/dictionary", true)]
        public async Task GetData()
        {
            var lang = this.HttpContext.GetRequestQueryData().Get("lang");
            
            string dictionaryName = ".json";

            switch (lang.ToLower())
            {
                case "es":
                case "fr":
                    dictionaryName = lang + dictionaryName;
                    break;
                default:
                    dictionaryName = "en" + dictionaryName;
                    break;

            }
            
            StreamReader reader = new StreamReader($"data/dictionary/{dictionaryName}");
            string content = reader.ReadToEnd();
            reader.Dispose();


            await this.HttpContext.SendStringAsync(content, "application/json", Encoding.Default);
        }

        [Route(HttpVerbs.Get, "/assetsVersions.json")]
        public async Task GetAssetsVersions()
        {
            var assetsVersion = this.HttpContext.GetRequestQueryData().Get("assetsVersion");
            var staticDataVersion = this.HttpContext.GetRequestQueryData().Get("staticDataVersion");
            var assetsVersionsJson = new JObject();

            assetsVersionsJson["assetsVersion"] = "5";//assetsVersion.ToString();
            assetsVersionsJson["staticDataVersion"] = staticDataVersion.ToString();
            assetsVersionsJson["changedFiles"] = new JArray(new string[]{ });
            

            await this.HttpContext.SendStringAsync(assetsVersionsJson.ToString(), "application/json", Encoding.Default);
        }

        [Route(HttpVerbs.Post, "/data/map")]
        public async Task GetApiDataMap()
        {
            string requestedPayload = await this.HttpContext.GetRequestBodyAsStringAsync();
            
            var mapDataRequest = JsonConvert.DeserializeObject<MapDataRequest>(requestedPayload);

            
            if (!File.Exists($"data/map/{mapDataRequest.@class}.json"))
            {
                this.HttpContext.SendStringAsync(JsonConvert.SerializeObject("[]"), "application/json", Encoding.Default);
            }
            
            StreamReader reader = new StreamReader($"data/map/{mapDataRequest.@class}.json");

            var data = await reader.ReadToEndAsync();
            
            reader.Dispose();
            
            await this.HttpContext.SendStringAsync(data, "application/json", Encoding.Default);
        }
    }
}