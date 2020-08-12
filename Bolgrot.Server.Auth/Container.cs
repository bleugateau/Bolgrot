using System.Data;
using System.Runtime.CompilerServices;
using Autofac;
using Bolgrot.Core.Common.Entity;
using Bolgrot.Core.Common.Managers;
using Bolgrot.Core.Common.Managers.Data;
using Bolgrot.Core.Common.Managers.Repository;
using Bolgrot.Core.Common.Repository;
using Bolgrot.Server.Auth.Managers;
using MySql.Data.MySqlClient;
using ServiceStack.OrmLite;

namespace Bolgrot.Server.Auth
{
    public static class Container
    {
        private static IContainer _container = null;


        public static void Initialize()
        {
            if (_container != null)
                return;

            var builder = new ContainerBuilder();

            builder.Register<IDbConnection>(c =>
                new OrmLiteConnection(new OrmLiteConnectionFactory(
                    "Server=localhost;Database=arkanic_auth;Uid=root;Pwd=;", MySql55Dialect.Provider)));

            //repository
            builder.RegisterType<AccountRepository>().As<IAccountRepository>().SingleInstance();
            builder.RegisterType<AuthRepositoryPersistManager>().AsSelf().OnActivating(e => e.Instance.StartPersister())
                .AutoActivate()
                .SingleInstance();

            //managers
            // builder.RegisterType<DataManager>().As<IDataManager>().OnActivating(e => e.Instance.Initialize())
            //     .AutoActivate()
            //     .SingleInstance();
            builder.RegisterType<HaapiManager>().As<IHaapiManager>().SingleInstance();

            _container = builder.Build();
        }

        public static IContainer Instance()
        {
            if (_container == null)
            {
                Initialize();
            }

            return _container;
        }
    }
}