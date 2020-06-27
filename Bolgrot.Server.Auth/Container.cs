using System.Data;
using Autofac;
using Bolgrot.Server.Auth.Managers;
using MySql.Data.MySqlClient;

namespace Bolgrot.Server.Auth
{
    public static class Container
    {
        private static IContainer _container = null;

        public static IContainer Instance()
        {

            if (_container == null)
            {
                var builder = new ContainerBuilder();

                builder.RegisterInstance(new MySqlConnection("Server=localhost;Database=arkanic_auth;Uid=root;Pwd=;"))
                    .As<IDbConnection>();
                builder.RegisterType<HaapiManager>().As<IHaapiManager>();

                _container = builder.Build();
            }

            return _container;
        }
    }
}