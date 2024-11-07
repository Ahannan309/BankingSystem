using System;
using BankingSystem.Interfaces;
using BankingSystem.Repository;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

        public ICustomerRepository Customers { get; }
        public IAccountRepository Accounts { get; }
        public ITransactionRepository Transactions { get; }
        public ILoanRepository Loans { get; }
        public IBranchRepository Branches { get; }


       
        public UnitOfWork (DbContext context,
            ICustomerRepository customer,
            IAccountRepository account,
            ITransactionRepository transaction,
            ILoanRepository loan,
            IBranchRepository branch)
        {
            _context = context;

            Customers = customer;   
            Accounts = account; 
            Transactions = transaction;
            Loans = loan;
            Branches = branch;
        }



        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
