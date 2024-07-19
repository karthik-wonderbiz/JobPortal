using JobPortal.Data;
using JobPortal.IRepository;
using JobPortal.IRepository.Employee;
using JobPortal.Model.Employee;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JobPortal.DTO.Employee.UrlInfoDto;

namespace JobPortal.Repository.Employee
{
    public class UrlInfoRepository : Repository<UrlInfo>, IUrlInfoRepository
    {
        private readonly JobPortalDbContext _dbContext;

        public UrlInfoRepository(JobPortalDbContext dbcontext) : base(dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task<IEnumerable<UrlInfo>> GetByUserId(long userId)
        {
            try
            {
                var urlInfos = await _dbContext.urlInfos
                    .Include(li => li.User)
                    .Include(li => li.UrlName)
                    .Where(li => li.UserId == userId)
                    .ToListAsync();

                return urlInfos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<UrlInfo>> GetAllAsync()
        {
            try
            {
                var urlInfos = await _dbContext.urlInfos
                    .Include(li => li.User)
                    .Include(li => li.UrlName)
                    .ToListAsync();

                return urlInfos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<UrlInfo> GetAsync(long id)
        {
            try
            {
                var urlInfo = await _dbContext.urlInfos
                    .Include(li => li.User)
                    .Include(li => li.UrlName)
                    .FirstOrDefaultAsync(li => li.Id == id); ;

                return urlInfo;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
