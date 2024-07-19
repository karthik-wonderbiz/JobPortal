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
    public class PersonalInfoRepository : Repository<PersonalInfo>, IPersonalInfoRepository
    {
        private readonly JobPortalDbContext _dbContext;
        public PersonalInfoRepository(JobPortalDbContext dbcontext) : base(dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task<IEnumerable<PersonalInfo>> GetByUserId(long userId)
        {
            try
            {
                var personalInfos = await _dbContext.personalInfos
                    .Include(li => li.User)
                    .Include(li => li.Gender)
                    .Where(li => li.UserId == userId)
                    .ToListAsync();

                return personalInfos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<PersonalInfo>> GetAllAsync()
        {
            try
            {
                var personalInfos = await _dbContext.personalInfos
                    .Include(li => li.User)
                    .Include(li => li.Gender)
                    .ToListAsync();

                return personalInfos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<PersonalInfo> GetAsync(long id)
        {
            try
            {
                var personalInfo = await _dbContext.personalInfos
                    .Include(li => li.User)
                    .Include(li => li.Gender)
                    .FirstOrDefaultAsync(li => li.Id == id); ;

                return personalInfo;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
