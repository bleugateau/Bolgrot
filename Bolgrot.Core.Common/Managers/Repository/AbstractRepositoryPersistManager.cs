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
    }
}