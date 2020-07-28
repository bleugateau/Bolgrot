using System.Collections.Concurrent;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bolgrot.Core.Common.Entity;
using Bolgrot.Core.Common.Repository;
using NLog;
using ServiceStack.OrmLite;

namespace Bolgrot.Core.Common.Managers.Repository
{
    public abstract class AbstractRepositoryPersistManager
    {
        
        public int DueTime { get; }
        
        protected IDbConnection _dbConnection;
        protected readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private Timer _timer;
        
        public AbstractRepositoryPersistManager(IDbConnection connection, int dueTime)
        {
            this._dbConnection = connection;
            this.DueTime = dueTime;
        }

        public void StartPersister()
        {
            this._timer = new Timer(PersistTimerCallback, new AutoResetEvent(true), 0, this.DueTime);
        }
        

        private void PersistTimerCallback(object state)
        {
            Task.Run(PersistCallback);
        }

        protected virtual Task PersistCallback()
        {
            return Task.CompletedTask;
        }
        
        /**
         * Persist edition on AbstractEntity
         */
        public void PersistEntities<T>(ConcurrentDictionary<int, T> entities)
        {
            var editedEntites = entities.Where(x => (x.Value as AbstractEntity).IsEdited || (x.Value as AbstractEntity).IsDeleted).Select(x => x.Value).ToList();
            
            this._logger.Debug($"{editedEntites.Count} entities need to be persisted ...");
            
            foreach (var entity in editedEntites)
            {
                if ((entity as AbstractEntity).IsEdited)
                {
                    this._dbConnection.Update<T>((T)entity);
                    
                    entities.AddOrUpdate((entity as AbstractEntity).Id, entity, (i, o) =>
                    {
                        (entity as AbstractEntity).IsEdited = false;
                        return o;
                    });

                    continue;
                }

                if ((entity as AbstractEntity).IsDeleted)
                {
                    //TODO soft delete ?
                }
            }
        }
    }
}