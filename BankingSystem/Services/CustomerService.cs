using BankingSystem.DTO;
using BankingSystem.Models;
using BankingSystem.Services;
using BankingSystem.UnitOfWork;
using System;

public class CustomerService : ICustomerService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IGenericService<Customer> _genericService;


    public CustomerService(IUnitOfWork unitOfWork, IGenericService<Customer> genericService)
    {
        _unitOfWork = unitOfWork;
        _genericService = genericService;
    }

    public async Task AddCustomer(AddCustomerDTO addCustomerDTO)
    {
        var customer = new Customer
        {
            Name = addCustomerDTO.Name,
            Email = addCustomerDTO.Email,
            PhoneNumber = addCustomerDTO.PhoneNumber,
            Address = addCustomerDTO.Address
        };

        _genericService.AddAsync(customer);
    }





    //public async Task CreateCustomerAsync(string name, string email, string phoneNumber, string address)
    //{

    //    var customer = new Customer
    //    {
    //        Name = name,
    //        Email = email,
    //        PhoneNumber = phoneNumber,
    //        Address = address
    //    };

    //    await _unitOfWork.Customers.AddAsync(customer);

    //    await _unitOfWork.SaveChangesAsync();
    //}
}