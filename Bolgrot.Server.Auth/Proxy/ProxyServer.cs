using System;
using System.Threading.Tasks;
using Bolgrot.Server.Auth.Controller;
using Bolgrot.Server.Auth.Network;
using EmbedIO;
using EmbedIO.Files;
using EmbedIO.Routing;
using EmbedIO.WebApi;
using EmbedIO.WebSockets;
using Swan.Logging;

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
            
            Logger.UnregisterLogger<ConsoleLogger>();

            return new WebServer(o => o
                    .WithUrlPrefix(this.ProxyUrl)
                    .WithMode(HttpListenerMode.EmbedIO)                    
                )
                .WithLocalSessionManager()
                .WithCors()
                .WithWebApi("/api", m => m
                    .WithController<DataController>()
                    .WithController<HaapiController>()
                )
                .WithWebApi("/haapi", m => m
                    .WithController<CmsController>()
                    .WithController<HaapiController>()
                )                
                .WithStaticFolder("/primus/primus.js", "data/primus.js", true, m => m.WithContentCaching(true).WithDefaultExtension(".js"))
                .WithModule(new AuthServer("/primus/"))
             //   .WithStaticFolder("/primus/", "data/", false, m => m.WithContentCaching(true).WithDefaultExtension(".js"))  
                .WithStaticFolder("/", "data/", true, m => m.WithContentCaching(true).WithDefaultExtension(".json"))
               .HandleHttpException(DataResponseForHttpException).HandleUnhandledException(DataResponseForHandleUnhandledException)
                ;
        }
        public static Task DataResponseForHttpException(IHttpContext context, IHttpException httpException)
        {
            context.Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
            return ResponseSerializer.Json(context, httpException.Message);
        }
        public static Task DataResponseForHandleUnhandledException(IHttpContext context, Exception exception)
        {
            context.Response.StatusCode = (int)System.Net.HttpStatusCode.OK; 
            return ResponseSerializer.Json(context, exception.Message);
        }

    }
}