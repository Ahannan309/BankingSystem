using BankingSystem.DTO;
using BankingSystem.Helper;
using BankingSystem.Models;

namespace BankingSystem.Services
{
    public interface ICustomerService
    {
        public Task<ResultMessage<Customer>> AddCustomer(CustomerDTO addCustomerDTO);
        public Task<ResultMessage<IEnumerable<Customer>>> GetAllCustomersAsync();
        public Task<ResultMessage<Customer>> DeleteCustomerAsync(int id);

        public Task<ResultMessage<Customer>> GetCustomerByIdAsync(int id);  
        public Task<ResultMessage<Customer>> UpdateCustomer(int id, CustomerDTO updateCustomerDTO);  

    }
}
