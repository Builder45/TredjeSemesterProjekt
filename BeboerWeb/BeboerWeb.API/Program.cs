using BeboerWeb.Application.UseCases.PersonUC;
using BeboerWeb.Application.UseCases.PersonUC.Interfaces;
using BeboerWeb.Application.Persistence;
using BeboerWeb.Application.UseCases.EjendomUC;
using BeboerWeb.Application.UseCases.EjendomUC.Interfaces;
using BeboerWeb.Application.UseCases.LejemaalUC;
using BeboerWeb.Application.UseCases.LejemaalUC.Interfaces;
using BeboerWeb.Application.UseCases.VicevaertUC;
using BeboerWeb.Application.UseCases.VicevaertUC.Interfaces;
using BeboerWeb.Persistence;
using BeboerWeb.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Database
builder.Services.AddDbContext<BeboerWebContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AzureConnection")));


// IOC repositories
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IEjendomRepository, EjendomRepository>();
builder.Services.AddScoped<ILejemaalRepository, LejemaalRepository>();
builder.Services.AddScoped<IVicevaertRepository, VicevaertRepository>();

// IOC usecases
builder.Services.AddScoped<ICreatePersonUseCase, CreatePersonUseCase>();
builder.Services.AddScoped<IGetPersonUseCase, GetPersonUseCase>();
builder.Services.AddScoped<IUpdatePersonUseCase, UpdatePersonUseCase>();
builder.Services.AddScoped<ICreateEjendomUseCase, CreateEjendomUseCase>();
builder.Services.AddScoped<IGetEjendomUseCase, GetEjendomUseCase>();
builder.Services.AddScoped<IUpdateEjendomUseCase, UpdateEjendomUseCase>();
builder.Services.AddScoped<ILinkVicevaertUseCase, LinkVicevaertUseCase>();
builder.Services.AddScoped<ICreateLejemaalUseCase, CreateLejemaalUseCase>();
builder.Services.AddScoped<IGetLejemaalUseCase, GetLejemaalUseCase>();

// Add services to the container
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
