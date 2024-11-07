using BankingSystem.Interfaces;
using BankingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.Repository
{
    public class LoanRepository : GenericRepository<Loan>, ILoanRepository
    {
        public LoanRepository(DbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Loan>> GetLoanByCustomerIdAsync(int customerId)
        {
            return await _dbSet.Where(l => l.CustomerId == customerId).ToListAsync();
        }
    }
}
