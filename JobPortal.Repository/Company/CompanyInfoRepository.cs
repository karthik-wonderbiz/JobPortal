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
    public class CompanyInfoRepository : Repository<CompanyInfo>, ICompanyInfoRepository
    {
        private readonly JobPortalDbContext _dbContext;
        public CompanyInfoRepository(JobPortalDbContext dbcontext) : base(dbcontext)
        {
            _dbContext = dbcontext;
        }
        public async Task<IEnumerable<CompanyInfo>> GetCompanyInfoByUserId(long userId)
        {
            try
            {
                var companyInfos = await _dbContext.companyInfos
                    .Include(li => li.User)
                    .Include(li => li.Company)
                    .ToListAsync();

                return companyInfos;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve company info by user id.", ex);
            }
        }
    }
}
