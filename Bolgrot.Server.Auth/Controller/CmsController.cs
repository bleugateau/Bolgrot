using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EmbedIO;
using EmbedIO.Routing;
using EmbedIO.WebApi;
using Newtonsoft.Json;

namespace Bolgrot.Server.Auth.Controller
{
    public class CmsController : WebApiController
    {
        [Route(HttpVerbs.Get, "/Cms/Items/Get", false)]
        public async Task GetData()
        {
            // List<News> news = new List<News>();
            //
            // news.Add(new News(
            //     "https://images-na.ssl-images-amazon.com/images/I/51o5ufE88nL._AC_SX450_.jpg",
            //     null, null, "Ten the boss", "ARTICLE", "event", true, "NEWS", new string[] {"DOFUS_TOUCH"}, 1,
            //     "<b>TEN LE BOSS</b>", "fr", "25/06/2020", 1592922600,
            //     "https://www.dofus-touch.com/fr/mmorpg/actualites/news/1200514-week-end-bonus-metier-notre-kickstarter",
            //     "https://www.dofus-touch.com/fr/mmorpg/actualites/news/1200514-week-end-bonus-metier-notre-kickstarter",
            //     "https://www.dofus-touch.com/fr/forum/107-actualite/26613-week-end-bonus-metier-notre-kickstarter")
            // );
            //
            // news.Add(new News(
            //     "https://images-na.ssl-images-amazon.com/images/I/51o5ufE88nL._AC_SX450_.jpg",
            //     null, null, "Ten the boss", "ARTICLE", "event", true, "NEWS", new string[] {"DOFUS_TOUCH"}, 1,
            //     "<b>TEN LE BOSS</b>", "fr", "25/06/2020", 1592922600,
            //     "https://www.dofus-touch.com/fr/mmorpg/actualites/news/1200514-week-end-bonus-metier-notre-kickstarter",
            //     "https://www.dofus-touch.com/fr/mmorpg/actualites/news/1200514-week-end-bonus-metier-notre-kickstarter",
            //     "https://www.dofus-touch.com/fr/forum/107-actualite/26613-week-end-bonus-metier-notre-kickstarter")
            // );
            //
            //
            // await this.HttpContext.SendStringAsync(JsonConvert.SerializeObject(news, Formatting.Indented), "json", Encoding.Default);
        }
    }
}