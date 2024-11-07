using BankingSystem.Interfaces;
using BankingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.Repository
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        public AccountRepository(DbContext context) : base(context)
        {
        }

        

        public async Task<IEnumerable<Account>> GetAccountByMinimalBalanceAsync(decimal minimumBalance)
        {
            return await _dbSet.Where(a => a.Balance >= minimumBalance).ToListAsync();
        }

        

     
    }
    }

