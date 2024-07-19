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
    public class EducationRepository : Repository<Education>, IEducationRepository
    {
        private readonly JobPortalDbContext _dbcontext;
        public EducationRepository(JobPortalDbContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<IEnumerable<Education>> GetEducationByUserId(long userId)
        {
            try
            {
                var education = await _dbcontext.educations
                    .Include(li => li.User)
                    .Include(li => li.Qualification)
                    .Where(li => li.UserId == userId)
                    .ToListAsync();

                return education;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Education>> GetAllAsync()
        {
            try
            {
                var education = await _dbcontext.educations
                    .Include(li => li.User)
                    .Include(li => li.Qualification)
                    .ToListAsync();

                return education;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Education> GetAsync(long id)
        {
            try
            {
                var education = await _dbcontext.educations
                    .Include(li => li.User)
                    .Include(li => li.Qualification)
                    .FirstOrDefaultAsync(li => li.Id == id); ;

                return education;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
