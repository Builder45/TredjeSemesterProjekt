using BeboerWeb.Application.UseCases.PersonUC;
using BeboerWeb.Application.UseCases.PersonUC.Interfaces;
using BeboerWeb.Application.Persistence;
using BeboerWeb.Application.UseCases.BookingUC;
using BeboerWeb.Application.UseCases.BookingUC.Interfaces;
using BeboerWeb.Application.UseCases.EjendomUC;
using BeboerWeb.Application.UseCases.EjendomUC.Interfaces;
using BeboerWeb.Application.UseCases.LejemaalUC;
using BeboerWeb.Application.UseCases.LejemaalUC.Interfaces;
using BeboerWeb.Application.UseCases.LejerUC;
using BeboerWeb.Application.UseCases.LejerUC.Interfaces;
using BeboerWeb.Application.UseCases.LokaleUC;
using BeboerWeb.Application.UseCases.LokaleUC.Interfaces;
using BeboerWeb.Application.UseCases.OpslagUC;
using BeboerWeb.Application.UseCases.OpslagUC.Interfaces;
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
builder.Services.AddScoped<ILejerRepository, LejerRepository>();
builder.Services.AddScoped<ILokaleRepository, LokaleRepository>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IOpslagRepository, OpslagRepository>();

// IOC usecases
builder.Services.AddScoped<ICreatePersonUseCase, CreatePersonUseCase>();
builder.Services.AddScoped<IGetPersonUseCase, GetPersonUseCase>();
builder.Services.AddScoped<IUpdatePersonUseCase, UpdatePersonUseCase>();
builder.Services.AddScoped<ICreateEjendomUseCase, CreateEjendomUseCase>();
builder.Services.AddScoped<IGetEjendomUseCase, GetEjendomUseCase>();
builder.Services.AddScoped<IUpdateEjendomUseCase, UpdateEjendomUseCase>();
builder.Services.AddScoped<ILinkVicevaertUseCase, LinkVicevaertUseCase>();
builder.Services.AddScoped<IAddVicevaertToEjendomUseCase, AddVicevaertToEjendomUseCase>();
builder.Services.AddScoped<ICreateLejemaalUseCase, CreateLejemaalUseCase>();
builder.Services.AddScoped<IGetLejemaalUseCase, GetLejemaalUseCase>();
builder.Services.AddScoped<IUpdateLejemaalUseCase, UpdateLejemaalUseCase>();
builder.Services.AddScoped<ICreateLejerUseCase, CreateLejerUseCase>();
builder.Services.AddScoped<IUpdateLejerUseCase, UpdateLejerUseCase>();
builder.Services.AddScoped<IGetLejerUseCase, GetLejerUseCase>();
builder.Services.AddScoped<ICreateLokaleUseCase, CreateLokaleUseCase>();
builder.Services.AddScoped<IUpdateLokaleUseCase, UpdateLokaleUseCase>();
builder.Services.AddScoped<IGetLokaleUseCase, GetLokaleUseCase>();
builder.Services.AddScoped<IIsActiveLejerUseCase, IsActiveLejerUseCase>();
builder.Services.AddScoped<IGetBookingUseCase, GetBookingUseCase>();
builder.Services.AddScoped<ICreateBookingUseCase, CreateBookingUseCase>();
builder.Services.AddScoped<IDeleteBookingUseCase, DeleteBookingUseCase>();
builder.Services.AddScoped<IGetOpslagUseCase, GetOpslagUseCase>();
builder.Services.AddScoped<ICreateOpslagUseCase, CreateOpslagUseCase>();
builder.Services.AddScoped<IUpdateOpslagUseCase, UpdateOpslagUseCase>();
builder.Services.AddScoped<IDeleteOpslagUseCase, DeleteOpslagUseCase>();

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
