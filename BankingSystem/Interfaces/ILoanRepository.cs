using BankingSystem.Models;
using BankingSystem.Repository;

namespace BankingSystem.Interfaces
{
    public interface ILoanRepository: IGenericRepository<Loan>
    {
        Task<IEnumerable<Loan>> GetLoanByCustomerIdAsync(int customerId);    
    }
}
