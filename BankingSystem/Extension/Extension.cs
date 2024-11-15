using BankingSystem.Data;
using BankingSystem.Helper;
using BankingSystem.Interfaces;
using BankingSystem.Repository;
using BankingSystem.Services;
using BankingSystem.UnitOfWork;

using Microsoft.EntityFrameworkCore;

namespace BankingSystem.Extension
{
    public static class Extension
    {
        public static void RegisterService(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
            services.AddScoped<ICustomerService, CustomerService>();


            //Mapper
            services.AddAutoMapper(typeof(AutoMapperProfile));
        }

        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<ILoanRepository, LoanRepository>();
            services.AddScoped<IBranchRepository, BranchRepository>();
            //services.AddScoped<IUnitOfWork, UnitOfWork>();

        }

        public static void RegisterDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BankDBContext>(options =>
            options.UseMySql(
            configuration.GetConnectionString("AppDbConnectionString"),
            new MySqlServerVersion(new Version(8, 0, 40)) 
             ));
        }
    }
}
