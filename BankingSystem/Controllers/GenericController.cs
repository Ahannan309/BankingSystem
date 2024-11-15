using AutoMapper;
using BankingSystem.Helper;
using BankingSystem.Services;
using Humanizer;
using Microsoft.AspNetCore.Mvc;

namespace BankingSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenericController<T, TDto> : ControllerBase, IGenericController<T, TDto> where T : class where TDto : class
    {

        //private ICustomerService genericService;
        private readonly IGenericService<T> _genericService; 
        private IMapper _mapper;

        public GenericController(IGenericService<T> genericService, IMapper mapper)
        {
            _genericService = genericService;
            _mapper = mapper;
        }

     

        [HttpPost]
        public async Task<ActionResult<T>> AddAsync([FromBody] TDto dto)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }

            try
            {
                var entity = _mapper.Map<T>(dto);
                var result = await _genericService.AddAsync(entity);

                if (!result.Status)
                {
                    return Conflict(result.Details);
                }

                return Ok(result);


            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, MessageUtility.HandleCreationException(ex));

            }
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<T>> Delete(int id)
        {
            if (id < ValidationConstants.MinimumValidId)
            {
                return BadRequest(MessageUtility.InvalidId);
            }

            try
            {
                var result = await _genericService.DeleteAsync(id);
                return !result.Status ? NotFound(result.Details) : Ok(result);

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, MessageUtility.HandleDeletionException(ex));
            }
        }


        [HttpGet]

        public async Task<ActionResult<IEnumerable<T>>> GetAllAsync()
        {
            try
            {
                var result = await _genericService.GetAllAsync();
                if (!result.Status)
                {
                    return NotFound(result.Details);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, MessageUtility.HandleFetchException(ex));

            }   
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<T>> GetByIdAsync(int id)
        {
            if (id < ValidationConstants.MinimumValidId) { return BadRequest(MessageUtility.InvalidId); }
            try
            {
                var result = await _genericService.GetByIdAsync(id);
                return !result.Status ? NotFound(result.Details) : Ok(result);

            }
            catch (Exception ex) {
                return StatusCode(StatusCodes.Status500InternalServerError, MessageUtility.HandleFetchException(ex));
            
            }
        }



        [HttpPut]
        public async Task<ActionResult<T>> Update(int id, [FromBody] TDto dto)
        {
            if (id < ValidationConstants.MinimumValidId) { return BadRequest(MessageUtility.InvalidId); }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var existingEntity = await _genericService.GetByIdAsync(id);
                if (existingEntity == null)
                {
                    return NotFound(MessageUtility.HandleNotFound(existingEntity.Details));

                }
               var a=  _mapper.Map(dto, existingEntity.Content);
                var entity = _mapper.Map<T>(a);

                var result = await _genericService.UpdateAsync(id, entity);

                return Ok(result);
            }
            catch (Exception ex) {
                return StatusCode(StatusCodes.Status500InternalServerError, MessageUtility.HandleFetchException(ex));
            }
        }
    }
}
