using BeboerWeb.API.Contract;
using BeboerWeb.MVC.Data;
using BeboerWeb.MVC.Services.PersonService;
using BeboerWeb.MVC.Services.EjendomService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BeboerWeb.MVC.Services;
using BeboerWeb.MVC.Services.BookingService;
using BeboerWeb.MVC.Services.LejemaalService;
using BeboerWeb.MVC.Services.LejerService;
using BeboerWeb.MVC.Services.LokaleService;
using BeboerWeb.MVC.Services.OpslagService;
using BeboerWeb.MVC.Services.VicevaertService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("AzureConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("BA", policy =>
        policy.RequireClaim("IsBA", "Yes"));
    options.AddPolicy("VV", policy =>
        policy.RequireClaim("IsVV", "Yes"));
    options.AddPolicy("Lejer", policy =>
        policy.RequireClaim("IsLejer", "Yes"));
});

// Temp password options
builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings.
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;
});

// Tillader brug af IHttpClientFactory i services
builder.Services.AddHttpClient();

builder.Services.Configure<ApiConfig>(
    builder.Configuration.GetSection("ApiConfig"));

builder.Services.AddScoped<IBrugerService, BrugerService>();

builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<IEjendomService, EjendomService>();
builder.Services.AddScoped<ILejemaalService, LejemaalService>();
builder.Services.AddScoped<ILejerService, LejerService>();
builder.Services.AddScoped<ILokaleService, LokaleService>();
builder.Services.AddScoped<IVicevaertService, VicevaertService>();
builder.Services.AddScoped<IOpslagService, OpslagService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();
//Disabled because of docker

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}");
app.MapRazorPages();

app.Run();
