using System;
using System.Collections.Concurrent;
using System.Data;
using System.Threading.Tasks;
using ServiceStack;
using ServiceStack.OrmLite;

namespace Bolgrot.Core.Common.Repository
{
    public interface IRepository<T>
    {
        public ConcurrentDictionary<int, T> Entities();
    }
    
    public abstract class Repository<T> : IRepository<T>
    {
        protected readonly IDbConnection DatabaseManager;
        
        private ConcurrentDictionary<int, T> _entities = new ConcurrentDictionary<int, T>();
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
            
            //if table not exist create it
            if (!this.DatabaseManager.TableExists<T>())
            {
                Console.WriteLine($"{typeof(T).Name.ToLower()} table created.");
                
                this.DatabaseManager.CreateTable<T>();
                this._isInitialized = true;
                return;
            }
            
            var allEntities = await this.DatabaseManager.SelectAsync<T>();

            foreach (var entity in allEntities)
            {
                this._entities.TryAdd(Convert.ToInt32(entity.GetObjectId()), entity);
            }
            
            
            Console.WriteLine($"{this._entities.Count} {typeof(T).Name} entity retrieved.");
            
            this._isInitialized = true;

            this.DatabaseManager.Close();
        }
        
    }
}