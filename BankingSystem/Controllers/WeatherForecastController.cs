using BankingSystem.DTO;
using BankingSystem.Helper;
using BankingSystem.Models;
using BankingSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace BankingSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        //private readonly IGenericService<Customer> _genericService;
        private readonly ICustomerService _customerService;

        public WeatherForecastController(ICustomerService customerService)
        {
            //_genericService = genericservice;
            _customerService = customerService;

        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(AddCustomerDTO customerDTO)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }

            try
            {
                var result = await _customerService.AddCustomer(customerDTO);

                if (!result.Success)
                {
                    return Conflict(result.Message);
                }

                return Ok(result.Message);


            }
            catch (Exception ex) { 
                return StatusCode(500, MessageHelper.ErrorOccured(ex.Message));
            
            }



            //return Ok("Customer Created Successfully");
        }


        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {

            try
            {
                var result = await _customerService.GetAllCustomersAsync();
                if (!result.Success)
                {
                    return NotFound(result.Message);
                }

                return Ok(result);
            }
            catch (Exception ex) {
                return StatusCode(500, MessageHelper.ErrorOccured(ex.Message));
            
            }
        }


        [HttpDelete("delete/{id}")]

        public async Task<IActionResult> DeleteCustomer(int id)
        {
            if(id <= 0)
            {
                return BadRequest("Invalid Id");
            }

            try
            {
                var result = await _customerService.DeleteCustomerAsync(id);
                return Ok(result);
            }
            catch (Exception ex) {

                return StatusCode(500, MessageHelper.ErrorOccured(ex.Message));
            }


        }









        //private static readonly string[] Summaries = new[]
        //{
        //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        //};

        //private readonly ILogger<WeatherForecastController> _logger;

        //public WeatherForecastController(ILogger<WeatherForecastController> logger)
        //{
        //    _logger = logger;
        //}

        //[HttpGet(Name = "GetWeatherForecast")]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}
    }
}
