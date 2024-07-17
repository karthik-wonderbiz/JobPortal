using JobPortal.Data;
using JobPortal.IRepository;
using JobPortal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Repository
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        public CityRepository(JobPortalDbContext dbcontext) : base(dbcontext)
        {
        }
    }
}
