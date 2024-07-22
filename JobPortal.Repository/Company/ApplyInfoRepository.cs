using JobPortal.Data;
using JobPortal.IRepository.Company;
using JobPortal.Model.Company;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Repository.Company
{
    public class ApplyInfoRepository : Repository<ApplyInfo>, IApplyInfoRepository
    {
        private readonly JobPortalDbContext _dbContext;

        public ApplyInfoRepository(JobPortalDbContext dbcontext) : base(dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task<IEnumerable<ApplyInfo>> GetApplyInfoByUserId(long userId)
        {
            try
            {
                var applyInfos = await _dbContext.applyInfos
                    .Include(li => li.User)
                    .Include(li => li.JobPost)
                    .ToListAsync();

                return applyInfos;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
