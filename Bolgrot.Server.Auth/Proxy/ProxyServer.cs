using System;
using System.Threading.Tasks;
using Bolgrot.Server.Auth.Controller;
using Bolgrot.Server.Auth.Network;
using EmbedIO;
using EmbedIO.Files;
using EmbedIO.Routing;
using EmbedIO.WebApi;
using EmbedIO.WebSockets;

namespace Bolgrot.Server.Auth.Proxy
{
    public class ProxyServer
    {
        public string ProxyUrl { get; set; }
        
        public ProxyServer(string address)
        {
            this.ProxyUrl = address;
        }

        public Task Start()
        {
            
            using (var server = this.CreateWebServer())
            {
                // Once we've registered our modules and configured them, we call the RunAsync() method.
                server.RunAsync();
                Console.ReadKey(true);
            }
            
            return Task.CompletedTask;
        }

        private WebServer CreateWebServer()
        {
            return new WebServer(o => o
                    .WithUrlPrefix(this.ProxyUrl)
                    .WithMode(HttpListenerMode.Microsoft)
                )
                .WithLocalSessionManager()
                .WithWebApi("/api", m => m
                    .WithController<DataController>()
                    .WithController<HaapiController>()
                )
                .WithWebApi("/haapi", m => m
                    .WithController<CmsController>()
                )
                .WithModule(new AuthServer("/primus/"))
                .WithStaticFolder("/optimus", "primus/", true, m => m
                    .WithContentCaching(true).WithDefaultExtension(".js")
                )
                .WithStaticFolder("/", "datas/", true);
        }
    }
}