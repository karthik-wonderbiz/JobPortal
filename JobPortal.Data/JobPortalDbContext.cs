using JobPortral.Model;
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
    }
}
