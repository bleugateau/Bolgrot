using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Bolgrot.Core.Common.Entities;
using Bolgrot.Server.Auth.Managers;
using Bolgrot.Server.Auth.Proxy.Requests;
using EmbedIO;
using EmbedIO.Routing;
using EmbedIO.WebApi;
using Newtonsoft.Json;

namespace Bolgrot.Server.Auth.Controller
{
    public class HaapiController : WebApiController
    {
        [Route(HttpVerbs.Get, "/haapi/getForumTopicsList")]
        public async Task GetForumTopicsList()
        {
            var lang = this.HttpContext.GetRequestQueryData().Get("lang");

            List<Topic> topics = new List<Topic>();
            // topics.Add(new Topic(1, "Mise à jour 0.0.1", "Test", false, "2020-06-16T09:30:00+02:00"));
            // topics.Add(new Topic(2, "Mise à jour 0.0.2", "[color=#2ecc71][b]MONSTRES[/b][/color][list][*]7pho au dessus XDDDDDD Les sorts du boss Nileza sont corrigés.[*]Les sorts du monstre Ecureuil d’Astrub sont corrigés.[/list]\n[color=#2ecc71][b]QUÊTES[/b][/color][list][*]Il est de nouveau possible de terminer la quête « Hérault de la Forêt » en étant aligné du côté de Bonta.[*]Il est de nouveau possible de terminer la quête « Pandala : Son air pur ».[*]Il est de nouveau possible de terminer la quête « Le règlement de comptes de Bworkékorall ».[/list]\n[color=#2ecc71][b]RECETTES[/b][/color][list][*]La recette de la Coiffe Cryochrone est corrigée.[*]Le texte du Plan de l’abreuvoir frigostien en Charme est corrigé afin de concorder avec la nouvelle recette.[*]Le texte de la Recette du masque de protection est corrigé afin de concorder avec la nouvelle recette.[/list]\n[color=#2ecc71][b]ÎLE DE L’ASCENSION[/b][/color][list][*]Une nouvelle rotation de l’île de l’Ascension commence dès maintenant ! [url=https://www.dofus-touch.com/fr/mmorpg/actualites/news/1196997-ile-ascension-rotation-9]En savoir plus[/url][/list]", false, "2020-06-02T09:00:00+02:00"));
            // topics.Add(new Topic(3, "Mise à jour 0.0.3", "Test", false, ""));
            
            await this.HttpContext.SendStringAsync(JsonConvert.SerializeObject(topics, Formatting.Indented), "json", Encoding.Default);
        }
        
        [Route(HttpVerbs.Get, "/haapi/getForumPostsList")]
        public async Task GetForumPostsList()
        {
            var lang = this.HttpContext.GetRequestQueryData().Get("lang");

            string content = "[]";

            await this.HttpContext.SendStringAsync(content, "json", Encoding.Default);
        }

        
        [Route(HttpVerbs.Post, "/haapi/Api/CreateApiKey")]
        public async Task CreateApiKey()
        {
            string requestedPayload = await this.HttpContext.GetRequestBodyAsStringAsync();
            requestedPayload = "{\"" + requestedPayload.Replace("=", "\":\"").Replace("&", "\",\"") + "\"}";

            var createApiKeyRequest = JsonConvert.DeserializeObject<CreateApiKeyRequest>(requestedPayload);

            var response = await Container.Instance().Resolve<IHaapiManager>()
                .CreateKey(createApiKeyRequest, this.HttpContext.RemoteEndPoint.Address.ToString());
            
            if (response.Contains("reason"))
            {
                this.HttpContext.Response.StatusCode = 601;
            }

            await this.HttpContext.SendStringAsync(response, "application/json", Encoding.Default);
        }
        
        [Route(HttpVerbs.Get, "/haapi/Account/CreateToken")]
        public async Task CreateToken()
        {
            
            string apikey = this.HttpContext.Request.Headers.Get("apikey");

            if (apikey.Length == 0)
            {
                throw new HttpException(601);
            }

            string response = await Container.Instance().Resolve<IHaapiManager>().BuildToken(apikey);
            
            
            await this.HttpContext.SendStringAsync(response, "application/json", Encoding.Default);
        }
    }
}