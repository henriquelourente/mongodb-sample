using MongoDB.Bson;
using MongoDB.Driver;
using Project4T.Domain.Interfaces.Entities;

namespace Project4T.Data.Repositories
{
    public class Repository<T> where T : IEntity<ObjectId>
    {
        protected IMongoClient _client;
        protected IMongoDatabase _database;

        public Repository(IMongoClient mongoClient)
        {
            //_mongoClient = mongoClient;
            _client = new MongoClient("mystring");
            _database = _client.GetDatabase("mydb");
        }

        public void Create(T entity)
        {
            var collection = _database.GetCollection<T>(typeof(T).Name);
            collection.InsertOne(entity);
        }

        public void Delete(ObjectId id)
        {
            var collection = _database.GetCollection<T>(typeof(T).Name);
            collection.DeleteOne(c => c.Id == id);
        }

        public void Update(T entity)
        {
            var customers = _database.GetCollection<T>(typeof(T).Name);
            customers.ReplaceOne(Builders<T>.Filter.Eq(r => r.Id, entity.Id), entity, new UpdateOptions() { IsUpsert = true });
        }
    }
}
