using System;
using Bolgrot.Core.Ankama.Protocol.Utils;
using Bolgrot.Core.Common.Config;
using Bolgrot.Server.Game.Network;

namespace Bolgrot.Server.Game
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
            
            var httpGameServer = new HttpServer("http://localhost:666");
            httpGameServer.Start().Wait();

        }
    }
}