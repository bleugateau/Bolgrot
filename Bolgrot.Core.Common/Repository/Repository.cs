using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Bolgrot.Core.Common.Entity;
using NLog;
using ServiceStack;
using ServiceStack.OrmLite;

namespace Bolgrot.Core.Common.Repository
{
    public interface IRepository<T>
    {
        public ConcurrentDictionary<int, T> Entities();
        public void PersistEntities();
    }

    public abstract class Repository<T> : IRepository<T> where T : AbstractEntity
    {
        protected readonly IDbConnection DatabaseManager;

        private ConcurrentDictionary<int, T> _entities = new ConcurrentDictionary<int, T>();
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private bool _isInitialized;


        public Repository(IDbConnection databaseManager)
        {
            this.DatabaseManager = databaseManager;
        }

        public ConcurrentDictionary<int, T> Entities()
        {
            if (!_isInitialized)
            {
                this.Initialize().Wait();
            }

            return this._entities;
        }

        private async Task Initialize()
        {
            this.DatabaseManager.Open();


            try
            {
                //if table not exist create it
                if (!this.DatabaseManager.TableExists<T>())
                {
                    this._logger.Info($"{typeof(T).Name.ToLower()} table created.");

                    this.DatabaseManager.CreateTable<T>();
                    this._isInitialized = true;
                    return;
                }


                var allEntities = await this.DatabaseManager.SelectAsync<T>(x => x.DeletedAt == null);

                foreach (var entity in allEntities)
                {
                    this._entities.TryAdd(Convert.ToInt32(entity.GetObjectId()), entity);
                }
            }

            catch(Exception ex)
            {
                this._logger.Error($"{ex.Message} for {typeof(T).Name}.");
            }


            this._logger.Info($"{this._entities.Count} {typeof(T).Name} entity retrieved.");

            this._isInitialized = true;

            this.DatabaseManager.Close();
        }

        /**
         * Persist edition
         */
        public void PersistEntities()
        {
            this.DatabaseManager.Open();

            var editedEntites = this.Entities().Where(x => x.Value.IsEdited || x.Value.IsDeleted).Select(x => x.Value)
                .ToList();

            this._logger.Debug($"{editedEntites.Count} {typeof(T).Name} need to be persisted ...");

            foreach (var entity in editedEntites)
            {
                if (entity.IsEdited || entity.DeletedAt != null)
                {
                    this.DatabaseManager.Update<T>(entity);

                    if (entity.IsEdited)
                    {
                        this.Entities().AddOrUpdate(entity.Id, entity, (i, o) =>
                        {
                            entity.IsEdited = false;
                            return o;
                        });
                    }

                    if (entity.IsDeleted)
                    {
                        this.Entities().TryRemove(entity.Id, out T removedEntity);
                    }

                    continue;
                }
            }

            this._logger.Debug($"Saving {typeof(T).Name} ...");

            this.DatabaseManager.Close();
        }
    }
}