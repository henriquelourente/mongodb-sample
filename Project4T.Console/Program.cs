using Project4T.Data.Repositories;
using Project4T.Domain.Contracts;
using Project4T.Domain.Entities;

namespace Project4T.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello World!");

            var customer = new Customer("billy smith", "billy@gmail.com", "30324510004");
            var validator = new CustomerValidator();
            var validationResult = validator.Validate(customer);

            if (validationResult.IsValid)
            {
                var customerRepository = new CustomerRepository(null);
                customerRepository.Create(customer);
            }
        }
    }
}
