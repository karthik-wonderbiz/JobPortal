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
    public class JodPostRepository : Repository<JobPost>, IJobPostRepository
    {
        public JodPostRepository(JobPortalDbContext dbcontext) : base(dbcontext)
        {
        }

        public Task<JobPost> GetJobPostByUserId(long userId)
        {
            throw new NotImplementedException();
        }
    }
}
