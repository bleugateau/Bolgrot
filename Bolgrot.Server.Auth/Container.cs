using System.Data;
using Autofac;
using Bolgrot.Core.Common.Managers;
using Bolgrot.Core.Common.Managers.Data;
using Bolgrot.Core.Common.Repository;
using Bolgrot.Server.Auth.Managers;
using MySql.Data.MySqlClient;
using ServiceStack.OrmLite;

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

                builder.Register<IDbConnection>(c =>
                    new OrmLiteConnection(new OrmLiteConnectionFactory(
                        "Server=localhost;Database=arkanic_auth;Uid=root;Pwd=;", MySql55Dialect.Provider)));

                //repository
                builder.Register<IAccountRepository>(c => new AccountRepository(c.Resolve<IDbConnection>())).SingleInstance();
                
                //managers
                builder.RegisterType<DataManager>().As<IDataManager>().OnActivating(e => e.Instance.Initialize()).SingleInstance();
                builder.RegisterType<HaapiManager>().As<IHaapiManager>().SingleInstance();

                _container = builder.Build();
            }

            return _container;
        }
    }
}