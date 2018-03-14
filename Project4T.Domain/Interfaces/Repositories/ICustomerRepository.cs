using Project4T.Domain.Entities;

namespace Project4T.Domain.Interfaces.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer GetByCPF(string cpf);
        Customer GetByName(string cpf);
    }
}
