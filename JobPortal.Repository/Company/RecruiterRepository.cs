using JobPortal.Data;
using JobPortal.IRepository.Company;
using JobPortal.IRepository.Employee;
using JobPortal.Model;
using JobPortal.Model.Company;
using JobPortal.Model.Employee;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Repository.Company
{
    public class RecruiterRepository : Repository<Recruiter>, IRecruiterRepository
    {
        private readonly JobPortalDbContext _dbContext;
        public RecruiterRepository(JobPortalDbContext dbcontext) : base(dbcontext)
        {
            _dbContext = dbcontext;
        }

        async Task<IEnumerable<Recruiter>> IRecruiterRepository.GetRecruiterByCompanyId(long companyId)
        {
            try
            {
                var recruiters = await _dbContext.recruiters
                    .Include(li => li.CompanyInfo)
                    .Where(li => li.CompanyId == companyId)
                    .ToListAsync();

                return recruiters;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
