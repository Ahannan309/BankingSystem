using Microsoft.AspNetCore.Mvc;

namespace BankingSystem.Controllers
{
    public interface IGenericController<T,TDto> where TDto : class
    {
        Task<ActionResult<IEnumerable<T>>> GetAllAsync();
        Task<ActionResult<T>> GetByIdAsync(int id);
        Task<ActionResult<T>> AddAsync([FromBody] TDto entity);
        Task<ActionResult<T>> Update(int id, [FromBody] TDto TDto);
        Task<ActionResult<T>> Delete(int id);
    }
}
