using BankingSystem.Models;
using BankingSystem.Repository;

namespace BankingSystem.Interfaces
{
    public interface ITransactionRepository: IGenericRepository<Transaction>
    {
        Task<IEnumerable<Transaction>> GetTransactionsByAccountIdAsync(int accountId); 
    }
}
