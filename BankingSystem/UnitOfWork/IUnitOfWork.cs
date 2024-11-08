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

        //int SaveAsync();
        Task<int> SaveAsync();


        //for generic service
        //IGenericRepository<T> GenericRepository<T>() where T : class;

        IGenericRepository<T> GetGenericRepositroy<T>() where T : class;
    }
}
