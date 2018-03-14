using MongoDB.Bson;
using Project4T.Domain.Interfaces.Entities;

namespace Project4T.Domain.Interfaces.Repositories
{
    public interface IRepository<T> where T : IEntity<ObjectId>
    {
        void Create(T entity);
        void Delete(ObjectId id);
        void Update(T entity);
    }
}
