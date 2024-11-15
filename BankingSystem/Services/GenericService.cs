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
                    Status = true,
                    Details = MessageUtility.HandleCreationSuccess(),
                    Content = entity
                };

            }
            catch (Exception ex)
            {
                return new ResultMessage<T>
                {
                    Status = false,
                    Details = MessageUtility.HandleCreationException(ex),
                    Content = entity
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
                        Status = false,
                        Details = MessageUtility.HandleNotFound(MessageUtility.Deletion)
                    };
                }
                await _repository.Remove(entity);
                _unitOfWork.SaveAsync();
                return new ResultMessage<T>
                {
                    Status = true,
                    Details = MessageUtility.HandleDeletionSuccess(),
                    Content = entity
                };
            }
            catch (Exception ex)
            {

                return new ResultMessage<T>
                {
                    Status = false,
                    Details = MessageUtility.HandleDeletionException(ex)
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
                        Status = false,
                        Details = MessageUtility.HandleNotFound(MessageUtility.Fetching)
                    };
                }

                return new ResultMessage<IEnumerable<T>>()
                {
                    Status = true,
                    Details = MessageUtility.HandleFetchSuccess(),
                    Content = result

                };
            }
            catch (Exception ex)
            {

                return new ResultMessage<IEnumerable<T>>()
                {
                    Status = false,
                    Details = MessageUtility.HandleFetchException(ex)
                };
            }
        }




        public async Task<ResultMessage<T>> GetByIdAsync(int id)
        {

            try
            {
                var result = await _repository.GetByIdAsync(id);
                if (result == null)
                {
                    return new ResultMessage<T>()
                    {
                        Status = false,
                        Details = MessageUtility.HandleNotFound(MessageUtility.Fetching)
                    };
                }
                return new ResultMessage<T>()
                {
                    Status = true,
                    Details = MessageUtility.HandleFetchSuccess(),
                    Content = result
                };
            }
            catch (Exception ex)
            {
                return new ResultMessage<T>
                {
                    Status = false,
                    Details = MessageUtility.HandleFetchException(ex)
                };
            }
        }

        public async Task<ResultMessage<T>> UpdateAsync(int id, T entity)
        {

            try
            {

                var entityData = await _repository.GetByIdAsync(id);
                if (entityData == null)
                {
                    return new ResultMessage<T>()
                    {
                        Status = false,
                        Details = MessageUtility.HandleNotFound(MessageUtility.Fetching)
                    };

                }

                await _repository.Update(entity);
                _unitOfWork.SaveAsync();
                return new ResultMessage<T>()
                {
                    Status = true,
                    Details = MessageUtility.HandleFetchSuccess(),
                    Content = entity
                };
            }
            catch (Exception ex) {
                return new ResultMessage<T>()
                {
                    Status = false,
                    Details = MessageUtility.HandleUpdateException(ex)
                };
            }
            }



    }   
}
