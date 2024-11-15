using BankingSystem.Data;
using BankingSystem.Extension;
using BankingSystem.Interfaces;
using BankingSystem.Repository;
using BankingSystem.Services;
using BankingSystem.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Register Unit Of Work
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.RegisterService(); 
builder.Services.RegisterRepositories();
builder.Services.RegisterDbContext(builder.Configuration);




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
