using BankingSystem.DTO;
using BankingSystem.Helper;
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

    public async Task<ResultMessage<Customer>> AddCustomer(CustomerDTO addCustomerDTO)
    {

        var existingCustomer = await _unitOfWork.Customers.GetCustomerByEmailAsync(addCustomerDTO.Email);
        if (existingCustomer != null) {
            return new ResultMessage<Customer>
            {
                Status = false,
                Details = MessageUtility.HandleAlreadyExist(existingCustomer.Email)

            };
        }

        var customer = new Customer
        {
            Name = addCustomerDTO.Name,
            Email = addCustomerDTO.Email,
            PhoneNumber = addCustomerDTO.PhoneNumber,
            Address = addCustomerDTO.Address    
        };

       return await _genericService.AddAsync(customer);
    }

    public async Task<ResultMessage<Customer>> DeleteCustomerAsync(int id)
    {
        return await _genericService.DeleteAsync(id);
    }

    public async Task<ResultMessage<IEnumerable<Customer>>> GetAllCustomersAsync()
    {
       return await _genericService.GetAllAsync();    
    }

    public async Task<ResultMessage<Customer>> GetCustomerByIdAsync(int id)
    {
        return await _genericService.GetByIdAsync(id);
    }

    public async Task<ResultMessage<Customer>> UpdateCustomer(int id, CustomerDTO updateCustomerDTO)
    {
        var customerEntity = await _unitOfWork.Customers.GetByIdAsync(id);
        if (customerEntity == null)
        {
            return new ResultMessage<Customer>
            {
                Status = false,
                Details = MessageUtility.HandleNotFound(MessageUtility.Fetching)
            };
        }

            customerEntity.Name = updateCustomerDTO.Name;
            customerEntity.Email = updateCustomerDTO.Email;
            customerEntity.PhoneNumber = updateCustomerDTO.PhoneNumber;
            customerEntity.Address = updateCustomerDTO.Address;
            return await _genericService.UpdateAsync(id, customerEntity);
            //why we passing id to generic service

    }


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
