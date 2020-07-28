using System;
using System.IO;
using System.Reflection;
using Bolgrot.Core.Common.Config;
using Bolgrot.Server.Auth.Managers;
using Bolgrot.Server.Auth.Proxy;
using NLog;
using NLog.Conditions;
using NLog.Targets;

namespace Bolgrot.Server.Auth
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bolgrot - Emulator for latest version of Dofus Touch by Ten.");
            
            //Apply config           
            NLog.LogManager.Configuration = LoggerConfig.GetConfig();

            //initialize
            Container.Initialize();

            var proxyServer = new ProxyServer("http://localhost:3000");
            proxyServer.Start().Wait();
        }
    }
}