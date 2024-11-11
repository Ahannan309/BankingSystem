using BankingSystem.DTO;
using BankingSystem.Helper;
using BankingSystem.Models;

namespace BankingSystem.Services
{
    public interface ICustomerService
    {
        public Task<ResultMessage<Customer>> AddCustomer(AddCustomerDTO addCustomerDTO);
        public Task<ResultMessage<IEnumerable<Customer>>> GetAllCustomersAsync();
        public Task<ResultMessage<Customer>> DeleteCustomerAsync(int id);
    }
}
