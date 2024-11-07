using BankingSystem.Models;
using BankingSystem.Repository;

namespace BankingSystem.Interfaces
{
    public interface IAccountRepository: IGenericRepository<Account>
    {
        Task<IEnumerable<Account>> GetAccountByMinimalBalanceAsync(decimal minimumBalance);
    }
}
