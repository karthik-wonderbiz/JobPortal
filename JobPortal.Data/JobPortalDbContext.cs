using JobPortal.Model;
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
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<Country> countries  { get; set; }
        public DbSet<Gender> genders { get; set; }

    }
}
