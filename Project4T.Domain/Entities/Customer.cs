using MongoDB.Bson;
using Project4T.Domain.Interfaces.Entities;

namespace Project4T.Domain.Entities
{
    public class Customer : IEntity<ObjectId>
    {
        public ObjectId Id { get; set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string CPF { get; private set; }

        public Customer(string name, string email, string cpf)
        {
            Id = ObjectId.GenerateNewId();
            this.Name = name;
            this.Email = email;
            this.CPF = cpf;
        }
    }
}
