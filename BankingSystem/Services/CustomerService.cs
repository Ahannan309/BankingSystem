using BankingSystem.Models;
using BankingSystem.UnitOfWork;
using System;


public class CustomerService
{
    private readonly IUnitOfWork _unitOfWork;

    public CustomerService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task CreateCustomerAsync(string name, string email, string phoneNumber, string address)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Customer name is required.", nameof(name));

        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email is required.", nameof(email));

        if (string.IsNullOrWhiteSpace(phoneNumber))
            throw new ArgumentException("Phone number is required.", nameof(phoneNumber));

        var customer = new Customer
        {
            Name = name,
            Email = email,
            PhoneNumber = phoneNumber,
            Address = address
        };

        await _unitOfWork.Customers.AddAsync(customer);

        await _unitOfWork.SaveChangesAsync();
    }
}