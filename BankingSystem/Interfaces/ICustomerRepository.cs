using BankingSystem.Models;
using BankingSystem.Repository;

namespace BankingSystem.Interfaces
{
    public interface ICustomerRepository: IGenericRepository<Customer>
    {
        Task<Customer> GetCustomerByEmailAsync(string email);
    }
}
