using JobPortal.Data;
using JobPortal.IRepository;
using JobPortal.IServices;
using JobPortal.Repository;
using JobPortal.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configuration = builder.Configuration;
var connectionString = configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<JobPortalDbContext>(option =>
    option.UseSqlServer(connectionString, b => b.MigrationsAssembly("JobPortal.API")));

/*Country*/
builder.Services.AddScoped<IGenderServices, GenderServices>();
builder.Services.AddScoped<IGenderRepository, GenderRepository>();

builder.Services.AddScoped<ICountryServices, CountryServices>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();

builder.Services.AddScoped<ILanguageServices, LanguageServices>();
builder.Services.AddScoped<ILanguageRepository, LanguageRepository>();

builder.Services.AddScoped<IShiftRepository, ShiftRepository>();
builder.Services.AddScoped<IShiftServices, ShiftServices>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
