using BankingSystem.Helper;
using BankingSystem.Repository;
using BankingSystem.UnitOfWork;
using Microsoft.AspNetCore.Http.HttpResults;

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

        public async Task<ResultMessage<T>> AddAsync(T entity)
        {

            try
            {
                await _repository.AddAsync(entity);

                //var a = await _unitOfWork.SaveAsync();
                var a = _unitOfWork.SaveAsync();

                return new ResultMessage<T>
                {
                    Success = true,
                    Message = MessageHelper.Success(typeof(T).Name, "Added"),
                    Data = entity
                };

            }
            catch (Exception ex)
            {
                return new ResultMessage<T>
                {
                    Success = false,
                    Message = MessageHelper.Exception(typeof(T).Name, "Adding", ex.Message),
                    Data = entity
                };
            }


        }

        public async Task<ResultMessage<T>> DeleteAsync(int id)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(id);
                if (entity == null)
                {
                    return new ResultMessage<T>
                    {
                        Success = false,
                        Message = MessageHelper.NotFound(typeof(T).Name)
                    };
                }
                await _repository.Remove(entity);
                _unitOfWork.SaveAsync();
                return new ResultMessage<T>
                {
                    Success = true,
                    Message = MessageHelper.Success(typeof(T).Name, "Deleted"),
                    Data = entity
                };
            }
            catch (Exception ex) {

                return new ResultMessage<T>
                {
                    Success = false,
                    Message = MessageHelper.Exception(typeof(T).Name, "deleting", ex.Message)
                };
            }
        }

        public async Task<ResultMessage<IEnumerable<T>>> GetAllAsync()
        {

            try
            {
                var result = await _repository.GetAllAsync();
                if (result == null)
                {
                    return new ResultMessage<IEnumerable<T>>()
                    {
                        Success = false,
                        Message = MessageHelper.NotFound(typeof(T).Name)
                    };
                }

                return new ResultMessage<IEnumerable<T>>()
                {
                    Success = true,
                    Message = MessageHelper.Success(typeof(T).Name, "fetched"),
                    Data = result

                };
            }
            catch (Exception ex)
            {

                return new ResultMessage<IEnumerable<T>>()
                {
                    Success = false,
                    Message = MessageHelper.Exception(typeof(T).Name, "fetching", ex.Message)
                };
            }
        }




        public async Task<ResultMessage<T>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResultMessage<T>> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }

}
