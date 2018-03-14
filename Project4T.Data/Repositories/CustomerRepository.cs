using MongoDB.Driver;
using Project4T.Domain.Entities;
using Project4T.Domain.Interfaces.Repositories;


namespace Project4T.Data.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(IMongoClient mongoClient)
           : base(mongoClient)
        {
           
        }

        public Customer GetByCPF(string cpf)
        {
            var customers = _database.GetCollection<Customer>("customer");
            return customers.Find(c => c.CPF == cpf).FirstOrDefault();
        }

        public Customer GetByName(string cpf)
        {
            var customers = _database.GetCollection<Customer>("customer");
            return customers.Find(c => c.CPF == cpf).FirstOrDefault();
        }
    }
}
