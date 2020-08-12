using System;
using System.Threading.Tasks;
using Bolgrot.Server.Game.Controller;
using EmbedIO;
using EmbedIO.Files;
using EmbedIO.WebApi;
using Swan.Logging;

namespace Bolgrot.Server.Game.Network
{
    public class HttpServer
    {
        public string Address { get; set; }
        
        public HttpServer(string address)
        {
            this.Address = address;
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
            
            Logger.UnregisterLogger<ConsoleLogger>();

            return new WebServer(o => o
                    .WithUrlPrefix(this.Address)
                    .WithMode(HttpListenerMode.EmbedIO)
                )
                .WithLocalSessionManager()
                .WithWebApi("/api", m => m
                    .WithController<TestController>()
                )
                .WithModule(new GameServer("/primus/"));
        }
    }
}