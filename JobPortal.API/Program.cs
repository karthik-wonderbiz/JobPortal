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

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserServices, UserServices>();

builder.Services.AddScoped<IGenderServices, GenderServices>();
builder.Services.AddScoped<IGenderRepository, GenderRepository>();

builder.Services.AddScoped<ICountryServices, CountryServices>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();

builder.Services.AddScoped<ILanguageServices, LanguageServices>();
builder.Services.AddScoped<ILanguageRepository, LanguageRepository>();

builder.Services.AddScoped<IShiftRepository, ShiftRepository>();
builder.Services.AddScoped<IShiftServices, ShiftServices>();

builder.Services.AddScoped<IStateRepository, StateRepository>();
builder.Services.AddScoped<IStateServices, StateServices>();

builder.Services.AddScoped<IWorkTypeRepository, WorkTypeRepository>();
builder.Services.AddScoped<IWorkTypeServices, WorkTypeServices>();

builder.Services.AddScoped<IEmploymentTypeRepository, EmploymentTypeRepository>();
builder.Services.AddScoped<IEmploymentTypeServices, EmploymentTypeServices>();

builder.Services.AddScoped<ITrainInfoRepository, TrainInfoRepository>();
builder.Services.AddScoped<ITrainInfoServices, TrainInfoServices>();

builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<ICityServices, CityServices>();

builder.Services.AddScoped<IUrlNameRepository, UrlNameRepository>();
builder.Services.AddScoped<IUrlNameServices, UrlNameServices>();

builder.Services.AddScoped<ISkillRepository, SkillRepository>();
builder.Services.AddScoped<ISkillServices, SkillServices>();

builder.Services.AddScoped<IDesignationRepository, DesignationRepository>();
builder.Services.AddScoped<IDesignationServices, DesignationServices>();

builder.Services.AddScoped<IQualificationRepository, QualificationRepository>();
builder.Services.AddScoped<IQualificationServices, QualificationServices>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
