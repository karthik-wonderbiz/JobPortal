using JobPortal.Data;
using JobPortal.IRepository;
using JobPortal.IRepository.Company;
using JobPortal.IRepository.Employee;
using JobPortal.IServices;
using JobPortal.IServices.Company;
using JobPortal.IServices.Employee;
using JobPortal.Repository;
using JobPortal.Repository.Company;
using JobPortal.Repository.Employee;
using JobPortal.Services;
using JobPortal.Services.Company;
using JobPortal.Services.Employee;
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

builder.Services.AddScoped<ITrainLineRepository, TrainLineRepository>();
builder.Services.AddScoped<ITrainLineServices, TrainLineServices>();

builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<ICityServices, CityServices>();

builder.Services.AddScoped<IUrlNameRepository, UrlNameRepository>();
builder.Services.AddScoped<IUrlNameServices, UrlNameServices>();

builder.Services.AddScoped<ISkillRepository, SkillRepository>();
builder.Services.AddScoped<ISkillServices, SkillServices>();

builder.Services.AddScoped<IDesignationRepository, DesignationRepository>();
builder.Services.AddScoped<IDesignationServices, DesignationServices>();

builder.Services.AddScoped<IPublicationRepository, PublicationRepository>();
builder.Services.AddScoped<IPublicationServices, PublicationServices>();

builder.Services.AddScoped<ILanguageInfoRepository, LanguageInfoRepository>();
builder.Services.AddScoped<ILanguageInfoServices, LanguageInfoServices>();

builder.Services.AddScoped<ISkillInfoRepository, SkillInfoRepository>();
builder.Services.AddScoped<ISkillInfoServices, SkillInfoServices>();

builder.Services.AddScoped<ILocationInfoRepository, LocationInfoRepository>();
builder.Services.AddScoped<ILocationInfoServices, LocationInfoServices>();

builder.Services.AddScoped<IQualificationRepository, QualificationRepository>();
builder.Services.AddScoped<IQualificationServices, QualificationServices>();

builder.Services.AddScoped<IEducationRepository, EducationRepository>();
builder.Services.AddScoped<IEducationServices, EducationServices>();

builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IProjectServices, ProjectServices>();

builder.Services.AddScoped<ICompanyInfoRepository, CompanyInfoRepository>();
builder.Services.AddScoped<ICompanyInfoServices, CompanyInfoServices>();

builder.Services.AddScoped<IWorkExperienceInfoRepository, WorkExperienceInfoRepository>();
builder.Services.AddScoped<IWorkExperienceInfoServices, WorkExperienceInfoServices>();

builder.Services.AddScoped<ICertificationInfoRepository, CertificationInfoRepository>();
builder.Services.AddScoped<ICertificationInfoServices, CertificationInfoServices>();

builder.Services.AddScoped<IPersonalInfoRepository, PersonalInfoRepository>();
builder.Services.AddScoped<IPersonalInfoServices, PersonalInfoServices>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
