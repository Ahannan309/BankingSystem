using System;
using BankingSystem.Data;
using BankingSystem.Interfaces;
using BankingSystem.Repository;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BankDBContext _context;
        private readonly IServiceProvider _serviceProvider; 
        private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();

        public ICustomerRepository Customers { get; }
        public IAccountRepository Accounts { get; }
        public ITransactionRepository Transactions { get; }
        public ILoanRepository Loans { get; }
        public IBranchRepository Branches { get; }


       
        public UnitOfWork (BankDBContext context,
            ICustomerRepository customer,
            IAccountRepository account,
            ITransactionRepository transaction,
            ILoanRepository loan,
            IBranchRepository branch, 
            IServiceProvider serviceProvider)
        {
            _context = context;

            Customers = customer;   
            Accounts = account; 
            Transactions = transaction;
            Loans = loan;
            Branches = branch;

            _serviceProvider = serviceProvider;
        }



        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IGenericRepository<T> GetGenericRepositroy<T>() where T : class
        {
            if (_repositories.ContainsKey(typeof(T)))
            {
                return (IGenericRepository<T>)_repositories[typeof(T)];
            }

            var repository = _serviceProvider.GetService<IGenericRepository<T>>();
            _repositories[typeof(T)] = repository;
            return repository;
        }

            
    }
}
