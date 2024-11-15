using BankingSystem.Helper;

namespace BankingSystem.Services
{
    public interface IGenericService<T> where T : class
    {
        Task<ResultMessage<T>> GetByIdAsync(int id);
        Task<ResultMessage<IEnumerable<T>>> GetAllAsync();
        Task<ResultMessage<T>> AddAsync(T entity);
        Task<ResultMessage<T>> UpdateAsync(int id,T entity);
        Task<ResultMessage<T>> DeleteAsync(int id);
    }
}
