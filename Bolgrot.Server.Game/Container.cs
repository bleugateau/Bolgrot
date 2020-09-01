using System.Data;
using Autofac;
using Bolgrot.Core.Common.Managers.Data;
using Bolgrot.Core.Common.Managers.Pathfinding;
using Bolgrot.Core.Common.Repository;
using Bolgrot.Server.Game.Managers;
using ServiceStack.OrmLite;

namespace Bolgrot.Server.Game
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
                    "Server=localhost;Database=arkanic_game;Uid=root;Pwd=;", MySql55Dialect.Provider)));

            //repository entities persister
            builder.RegisterType<RepositoryPersistManager>().AsSelf().OnActivating(e => e.Instance.StartPersister())
                .AutoActivate()
                .SingleInstance();
            
            //repository
            builder.RegisterType<CharacterRepository>().As<ICharacterRepository>().SingleInstance();

            /* MANAGER */
            
            //character
             builder.RegisterType<CharacterManager>().As<ICharacterManager>()
                            .AutoActivate()
                            .SingleInstance();
             
            //map
            builder.RegisterType<PathfinderManager>().As<IPathfinderManager>()
                .AutoActivate()
                .SingleInstance();
            
            builder.RegisterType<MapManager>().As<IMapManager>()
                .AutoActivate()
                .SingleInstance();

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