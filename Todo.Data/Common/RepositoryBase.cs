using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using Todo.Data.Interfaces;
using Todo.Domain.Business;

namespace Todo.Data.Common
{
    public abstract class RepositoryBase<T> where T : Entity
    {
        protected readonly IMongoCollection<T> _collection;

        protected RepositoryBase(IMongoDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _collection = database.GetCollection<T>(settings.TodoCollectionName);
        }

        public virtual async Task<List<T>> Get()
        {
            return (await _collection.FindAsync(entity => true)).ToList();   
        }

        public virtual async Task<T> Get(string id)
        {
            return (await _collection.FindAsync<T>(entity => entity.Id == id)).FirstOrDefault();
        }

        public virtual async Task<T> Create(T entity)
        {
            await _collection.InsertOneAsync(entity);
            return entity;
        }

        public virtual async Task Update(string id, T entityIn)
        {
            await _collection.ReplaceOneAsync(entity => entity.Id == id, entityIn);
        }

        public virtual async Task Remove(string id)
        {
            await _collection.DeleteOneAsync(entity => entity.Id == id);
        }
    }
}
