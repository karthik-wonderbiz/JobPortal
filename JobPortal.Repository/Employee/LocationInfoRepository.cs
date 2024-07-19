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
    public class LocationInfoRepository : Repository<LocationInfo>, ILocationInfoRepository
    {
        private readonly JobPortalDbContext _dbContext;

        public LocationInfoRepository(JobPortalDbContext dbcontext) : base(dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task<IEnumerable<LocationInfo>> GetByUserId(long userId)
        {
            try
            {
                var locationInfo = await _dbContext.locationInfos
                    .Include(li => li.User)
                    .Include(li => li.City)
                    .Include(li => li.State)
                    .Include(li => li.Country)
                    .Include(li => li.TrainInfo)
                    .Where(li => li.UserId == userId)
                    .ToListAsync();

                return locationInfo;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<LocationInfo>> GetAllAsync()
        {
            try
            {
                var locationInfos = await _dbContext.locationInfos
                    .Include(li => li.User)
                    .Include(li => li.City)
                    .Include(li => li.State)
                    .Include(li => li.Country)
                    .Include(li => li.TrainInfo)
                    .ToListAsync();

                return locationInfos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<LocationInfo> GetAsync(long id)
        {
            try
            {
                var locationInfo = await _dbContext.locationInfos
                    .Include(li => li.User)
                    .Include(li => li.City)
                    .Include(li => li.State)
                    .Include(li => li.Country)
                    .Include(li => li.TrainInfo)
                    .FirstOrDefaultAsync(li => li.Id == id); ;

                return locationInfo;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
