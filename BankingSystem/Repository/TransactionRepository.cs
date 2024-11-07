using BankingSystem.Interfaces;
using BankingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.Repository
{
    public class TransactionRepository : GenericRepository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(DbContext context) : base(context)
        {
        }


        public async Task<IEnumerable<Transaction>> GetTransactionsByAccountIdAsync(int accountId)
        {
            return await _dbSet.Where(t => t.AccountId == accountId).ToListAsync();
        }

    }
}
