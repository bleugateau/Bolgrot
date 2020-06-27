using System;
using Bolgrot.Server.Auth.Proxy;

namespace Bolgrot.Server.Auth
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            var proxyServer = new ProxyServer("http://localhost:3000");
            proxyServer.Start().Wait();
        }
    }
}