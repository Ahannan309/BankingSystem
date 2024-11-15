using AutoMapper;
using BankingSystem.DTO;
using BankingSystem.Models;

namespace BankingSystem.Helper
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CustomerDTO, Customer>();
        }
    }
}
