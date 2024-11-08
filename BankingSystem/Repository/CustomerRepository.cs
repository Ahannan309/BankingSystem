using BankingSystem.Data;
using BankingSystem.Interfaces;
using BankingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.Repository
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {

        public CustomerRepository(BankDBContext context):base(context)
        {
            
        }
        public async Task<Customer> GetCustomerByEmailAsync(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(c => c.Email == email);
        }
    }
}
