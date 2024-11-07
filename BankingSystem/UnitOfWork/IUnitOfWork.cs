using BankingSystem.Interfaces;
using BankingSystem.Repository;

namespace BankingSystem.UnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {
        ICustomerRepository Customers {  get; }
        IAccountRepository Accounts { get; }
        ITransactionRepository Transactions { get; }

        ILoanRepository Loans { get; }
        IBranchRepository Branches { get; }
        //object CustomerRepository { get; }

        Task<int> SaveChangesAsync();


        //for generic service

        //IGenericRepository<> GetGenericRepositroy<T>() where T : class;
    }
}
