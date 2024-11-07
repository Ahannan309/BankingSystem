using BankingSystem.Models;
using BankingSystem.Repository;

namespace BankingSystem.Interfaces
{
    public interface IBranchRepository: IGenericRepository<Branch>
    {
        Task<IEnumerable<Branch>> GetBrachesWithMinimumCustomersAsync(int minimumCustomers);
    }
}
