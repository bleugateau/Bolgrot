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
        public void AddEntity(T entity);
        public void UpdateEntity(int key, T entity);
        public void DeleteEntity(T entity);
    }

    public abstract class Repository<T> : IRepository<T> where T : AbstractEntity
    {
        protected readonly IDbConnection DatabaseManager;

        private ConcurrentDictionary<int, T> _entities = new ConcurrentDictionary<int, T>();
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private bool _isInitialized;
        private int _autoIncrement = 1;


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
                

                var allEntities = await this.DatabaseManager.SelectAsync<T>();
                var informationSchemaResults = await this.DatabaseManager.ColumnAsync<string>($"SELECT AUTO_INCREMENT FROM information_schema.TABLES WHERE TABLE_SCHEMA = \"{this.DatabaseManager.Database}\" AND TABLE_NAME = \"{typeof(T).Name.ToLower()}\"");

                this._autoIncrement = Convert.ToInt32(informationSchemaResults.First());

                foreach (var entity in allEntities)
                {
                    this._entities.TryAdd(Convert.ToInt32(entity.GetObjectId()), entity);
                }
            }

            catch (Exception ex)
            {
                this._logger.Error($"{ex.Message} for {typeof(T).Name}.");
            }


            this._logger.Info($"{this._entities.Count} {typeof(T).Name} entity retrieved.");

            this._isInitialized = true;

            this.DatabaseManager.Close();
        }


        /**
         * Add entity
         */
        public void AddEntity(T entity)
        {
            entity.Id = this._autoIncrement;
            this._autoIncrement += 1;
            
            if (this._entities.ContainsKey(entity.Id))
            {
                entity.Id = this._autoIncrement;
                this._autoIncrement += 1;
            }
            
            entity.IsNew = true;
            this._entities.TryAdd(entity.Id, entity);
        }
        
        
        /**
         * Update entity
         */
        public void UpdateEntity(int key, T entity)
        {
            //retrieve entity by key
            this._entities.TryGetValue(key, out T baseEntity);
            
            if (baseEntity != null)
            {
                this._entities.AddOrUpdate(key, baseEntity, (i, editedEntity) =>
                {
                    editedEntity = entity;
                    editedEntity.IsEdited = true;
                    
                    return editedEntity;
                });
            }
        }

        /**
         * Delete entity
         */
        public void DeleteEntity(T entity)
        {
            this._entities.AddOrUpdate(entity.Id, entity, (i, editedEntity) =>
            {
                editedEntity.IsDeleted = true;
                return editedEntity;
            });
        }
        
        /**
         * Persist edition
         */
        public void PersistEntities()
        {
            this.DatabaseManager.Open();

            var editedEntites = this.Entities().Where(x => x.Value.IsEdited || x.Value.IsNew || x.Value.IsDeleted)
                .Select(x => x.Value)
                .ToList();

            this._logger.Debug($"{editedEntites.Count} {typeof(T).Name} need to be persisted ...");

            try
            {
                foreach (var entity in editedEntites)
                {
                    if (entity.IsNew || entity.IsEdited)
                    {
                        //insert if new entity
                        if (entity.IsNew)
                        {
                            this.DatabaseManager.Insert<T>(entity);
                        }
                        else if (entity.IsEdited)
                        {
                            this.DatabaseManager.Update<T>(entity);
                        }

                        //set flag IsEdited & IsNew to false
                        this.Entities().AddOrUpdate(entity.Id, entity, (i, o) =>
                        {
                            o.IsEdited = false;
                            o.IsNew = false;
                            return o;
                        });
                    }


                    if (entity.IsDeleted)
                    {
                        this.DatabaseManager.Delete<T>(entity);
                        this.Entities().TryRemove(entity.Id, out T removedEntity);
                    }
                }
                
                this._logger.Debug($"{typeof(T).Name} successfully saved !");
            }
            catch (Exception ex)
            {
                this._logger.Error(ex.Message);
            }

            this.DatabaseManager.Close();
        }
    }
}