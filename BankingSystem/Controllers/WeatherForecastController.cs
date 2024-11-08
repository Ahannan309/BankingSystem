using BankingSystem.DTO;
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

            await _customerService.AddCustomer(customerDTO);
            return Ok("Customer Created Successfully");
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
