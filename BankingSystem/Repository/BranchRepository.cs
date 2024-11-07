using BankingSystem.Interfaces;
using BankingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.Repository
{
    public class BranchRepository : GenericRepository<Branch>, IBranchRepository
    {
        public BranchRepository(DbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Branch>> GetBrachesWithMinimumCustomersAsync(int minimumCustomers)
        {
            return await _dbSet.Where(b => b.Customers.Count >= minimumCustomers).ToListAsync();
        }
    }
}
