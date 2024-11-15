using AutoMapper;
using BankingSystem.DTO;
using BankingSystem.Models;
using BankingSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace BankingSystem.Controllers
{

    public class CustomerController : GenericController<Customer,CustomerDTO>
    {

        public CustomerController(IGenericService<Customer> customerService, IMapper mapper) : base(customerService, mapper)
        {
           
        }




    }
}
