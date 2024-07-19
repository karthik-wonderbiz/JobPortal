using JobPortal.Model;
using JobPortal.Model.Company;
using JobPortal.Model.Employee;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Data
{
    public class JobPortalDbContext : DbContext
    {
        public JobPortalDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Language>  languages { get; set; }
        public DbSet<Shift> shifts { get; set; }
        public DbSet<Country> countries  { get; set; }
        public DbSet<Gender> genders { get; set; }
        public DbSet<WorkType> workTypes { get; set; }
        public DbSet<TrainLine> trainLines { get; set; }
        public DbSet<State> states { get; set; }
        public DbSet<EmploymentType> employmentTypes { get; set; }
        public DbSet<Skill> skills { get; set; }
        public DbSet<City> cities { get; set; }
        public DbSet<UrlName> urlNames { get; set; }
        public DbSet<Designation> designations { get; set; }
        public DbSet<Qualification> qualifications { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<SkillInfo> skillInfos { get; set; }
        public DbSet<LanguageInfo> languageInfos { get; set; }
        public DbSet<Publication> publications { get; set; }
        public DbSet<CompanyInfo> companies { get; set; }
        public DbSet<LocationInfo> locationInfos { get; set; }
        public DbSet<Education> educations { get; set; }
        public DbSet<WorkExperienceInfo> workExperienceInfos { get; set; }
        public DbSet<CertificationInfo> certificationInfos { get; set; }
        public DbSet<UrlInfo> urlInfos { get; set; }
        public DbSet<Project> projects { get; set; }

        public DbSet<Recruiter> recruiters { get; set; }
        public DbSet<ContactPerson> contactPersons { get; set; }
        public DbSet<JobPost> jobPosts { get; set; }
        public DbSet<ApplyInfo> applyInfos { get; set; }

        public DbSet<PersonalInfo> personalInfos { get; set; }

        public DbSet<JobPost> jobPosts { get; set; }
    }
}
