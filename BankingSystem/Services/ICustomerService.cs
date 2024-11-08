using BankingSystem.DTO;

namespace BankingSystem.Services
{
    public interface ICustomerService
    {
        public Task AddCustomer(AddCustomerDTO addCustomerDTO);
    }
}
