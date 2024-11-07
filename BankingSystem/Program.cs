using BankingSystem.Data;
using BankingSystem.Interfaces;
using BankingSystem.Repository;
using BankingSystem.UnitOfWork;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Connection
//var provider = builder.Services.BuildServiceProvider();
//var config = provider.GetRequiredService<IConfiguration>();
//var connectionString = builder.Configuration.GetConnectionString("AppDbConnectionString");
//builder.Services.AddDbContext<BankDBContext>(options => options.UseMySql(connectionString,ServerVersion.AutoDetect(connectionString)));
//builder.Services.AddDbContext<BankDBContext>(item => item.UseMySql(config.GetConnectionString("AppDbConnectionString")));


builder.Services.AddDbContext<BankDBContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("AppDbConnectionString"),
        new MySqlServerVersion(new Version(8, 0, 40)) // specify the MySQL version you're using
    ));

//Register Repositories
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddScoped<ILoanRepository, LoanRepository>();
builder.Services.AddScoped<IBranchRepository, BranchRepository>();

//Register Unit Of Work
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
