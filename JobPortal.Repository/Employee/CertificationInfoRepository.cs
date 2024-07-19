using JobPortal.Data;
using JobPortal.IRepository.Employee;
using JobPortal.Model.Employee;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Repository.Employee
{
    public class CertificationInfoRepository : Repository<CertificationInfo>, ICertificationInfoRepository
    {
        private readonly JobPortalDbContext _dbContext;

        public CertificationInfoRepository(JobPortalDbContext dbcontext) : base(dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task<IEnumerable<CertificationInfo>> GetByUserId(long userId)
        {
            try
            {
                var certificationInfo = await _dbContext.certificationInfos
                    .Include(li => li.User)
                    .Where(li => li.UserId == userId)
                    .ToListAsync();

                return certificationInfo;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<CertificationInfo>> GetAllAsync()
        {
            try
            {
                var certificationInfos = await _dbContext.certificationInfos
                    .Include(li => li.User)
                    .ToListAsync();

                return certificationInfos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<CertificationInfo> GetAsync(long id)
        {
            try
            {
                var certificationInfo = await _dbContext.certificationInfos
                    .Include(li => li.User)
                    .FirstOrDefaultAsync(li => li.Id == id); ;

                return certificationInfo;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
