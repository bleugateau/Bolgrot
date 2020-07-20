using System;
using System.IO;
using System.Reflection;
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
            
            var config = new NLog.Config.LoggingConfiguration();
            
            //Targets where to log to: File and Console
            var logfile = new NLog.Targets.FileTarget("logfile") {FileName = "file.txt"};
            var consoleTarget = new ColoredConsoleTarget();

            var highlightRule = new ConsoleRowHighlightingRule();
            consoleTarget.WordHighlightingRules.Add(new ConsoleWordHighlightingRule("INFO", ConsoleOutputColor.DarkBlue, ConsoleOutputColor.NoChange));
            consoleTarget.WordHighlightingRules.Add(new ConsoleWordHighlightingRule("DEBUG", ConsoleOutputColor.DarkGreen, ConsoleOutputColor.NoChange));
            
            //Rules for mapping loggers to targets            
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, consoleTarget);
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);
            
            //Apply config           
            NLog.LogManager.Configuration = config;

            //initialize
            Container.Initialize();

            var proxyServer = new ProxyServer("http://localhost:3000");
            proxyServer.Start().Wait();
        }
    }
}