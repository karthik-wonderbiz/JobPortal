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
    public class WorkExperienceInfoRepository : Repository<WorkExperienceInfo>, IWorkExperienceInfoRepository
    {
        private readonly JobPortalDbContext _dbContext;

        public WorkExperienceInfoRepository(JobPortalDbContext dbcontext) : base(dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task<IEnumerable<WorkExperienceInfo>> GetByUserId(long userId)
        {
            try
            {
                var workExperienceInfo = await _dbContext.workExperienceInfos
                    .Include(li => li.User)
                    .Include(li => li.WorkType)
                    .Include(li => li.EmploymentType)
                    .Include(li => li.Designation)
                    .Where(li => li.UserId == userId)
                    .ToListAsync();

                return workExperienceInfo;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<WorkExperienceInfo>> GetAllAsync()
        {
            try
            {
                var workExperienceInfo = await _dbContext.workExperienceInfos
                    .Include(li => li.User)
                    .Include(li => li.WorkType)
                    .Include(li => li.EmploymentType)
                    .Include(li => li.Designation)
                    .ToListAsync();

                return workExperienceInfo;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<WorkExperienceInfo> GetAsync(long id)
        {
            try
            {
                var workExperienceInfo = await _dbContext.workExperienceInfos
                    .Include(li => li.User)
                    .Include(li => li.WorkType)
                    .Include(li => li.EmploymentType)
                    .Include(li => li.Designation)
                    .FirstOrDefaultAsync(li => li.Id == id); ;

                return workExperienceInfo;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
