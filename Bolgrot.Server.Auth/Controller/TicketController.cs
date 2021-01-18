using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Bolgrot.Server.Auth.Managers;
using EmbedIO;
using EmbedIO.Routing;
using EmbedIO.WebApi;
using Newtonsoft.Json;

namespace Bolgrot.Server.Auth.Controller
{
    public class TicketController : WebApiController
    {
        [Route(HttpVerbs.Get, "/get", false)]
        public async Task GetData()
        {
            if (!(this.Request.RemoteEndPoint.Address.ToString() == "::1" || Container.Instance().Resolve<IWorldServerManager>().Servers().Any(x => IPAddress.Parse((x.Address.ToLower() == "localhost") ? "127.0.0.1": x.Address).Equals(this.Request.RemoteEndPoint.Address))))
                throw new HttpException(601);
            //var key = this.HttpContext.GetRequestQueryData().Get("secure_key");
           // if (key != "secret_key" || key.Length == 0)// update to a system that verify the world in dbb and enable only in specify IP
                //throw new HttpException(601);

            //string ticket = this.HttpContext.Request.Headers.Get("ticket");
            string ticket = this.HttpContext.GetRequestQueryData().Get("ticket");

            if (ticket.Length == 0)
            {
                throw new HttpException(601);
            }

            string response = await Container.Instance().Resolve<ITicketManager>().GetTicket(ticket);

            if (response.Contains("reason"))
            {
                this.HttpContext.Response.StatusCode = 601;
            }

            await this.HttpContext.SendStringAsync(response, "application/json", Encoding.Default);


        }

    }
}