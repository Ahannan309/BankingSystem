using BankingSystem.Repository;
using BankingSystem.UnitOfWork;

namespace BankingSystem.Services
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<T> _repository; 
        //private readonly 

        public GenericService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.GetGenericRepositroy<T>();
        }

        public async Task AddAsync(T entity)   
        {

            try
            {
                await _repository.AddAsync(entity);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to add entity of type {typeof(T).Name}. See inner exception for details.", ex);        
            }
               
           
        }
        
        public Task<T> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<T> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
