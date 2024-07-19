using JobPortal.Data;
using JobPortal.IRepository.Company;
using JobPortal.Model.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Repository.Company
{
    public class RecruiterRepository : Repository<Recruiter>, IRecruiterRepository
    {
        public RecruiterRepository(JobPortalDbContext dbcontext) : base(dbcontext)
        {
        }
    }
}
