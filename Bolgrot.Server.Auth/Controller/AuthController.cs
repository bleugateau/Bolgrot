using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Bolgrot.Core.Common.Managers;
using Bolgrot.Core.Common.Managers.Data;
using Bolgrot.Server.Auth.Network;
using Bolgrot.Server.Auth.Proxy.Requests;
using EmbedIO;
using EmbedIO.Routing;
using EmbedIO.WebApi;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bolgrot.Server.Auth.Controller
{
    public class AuthController : WebApiController
    {
        [Route(HttpVerbs.Any, "/", true)]
        public async Task GetData()
        {
            var client = new AuthServer("/primus/");
                 StreamReader reader = new StreamReader($"primus/primus.js");
            string content = reader.ReadToEnd();
            reader.Dispose();


            await this.HttpContext.SendStringAsync(content, "application/json", Encoding.Default);
 
        }


    }
}