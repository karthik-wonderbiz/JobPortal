using JobPortal.Data;
using JobPortal.IRepository.Company;
using JobPortal.Model;
using JobPortal.Model.Company;
using JobPortal.Model.Employee;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Repository.Company
{
    public class JodPostRepository : Repository<JobPost>, IJobPostRepository
    {
        private readonly JobPortalDbContext _dbcontext;
        public JodPostRepository(JobPortalDbContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<IEnumerable<JobPost>> GetJobPostByUserId(long companyId)
        {
            try
            {
                var jobPosts = await _dbcontext.jobPosts
                    .Include(li => li.CompanyInfo)
                    .Include(li => li.Recruiter)
                    .Include(li => li.Designation)
                    .Include(li => li.Skill)
                    .Include(li => li.TrainLine)
                    .Include(li => li.Language)
                    .Include(li => li.Shift)
                    .Include(li => li.WorkType)
                    .Include(li => li.EmploymentType)
                    .Include(li => li.Qualification)
                    .Where(li => li.CompanyId == companyId)
                    .ToListAsync();

                return jobPosts;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<JobPost>> GetAllAsync()
        {
            try
            {
                var jobPosts = await _dbcontext.jobPosts
                    .Include(li => li.CompanyInfo)
                    .Include(li => li.Recruiter)
                    .Include(li => li.Designation)
                    .Include(li => li.Skill)
                    .Include(li => li.TrainLine)
                    .Include(li => li.Language)
                    .Include(li => li.Shift)
                    .Include(li => li.WorkType)
                    .Include(li => li.EmploymentType)
                    .Include(li => li.Qualification)
                    .ToListAsync();

                return jobPosts;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<JobPost> GetAsync(long id)
        {
            try
            {
                var jobPosts = await _dbcontext.jobPosts
                    .Include(li => li.CompanyInfo)
                    .Include(li => li.Recruiter)
                    .Include(li => li.Designation)
                    .Include(li => li.Skill)
                    .Include(li => li.TrainLine)
                    .Include(li => li.Language)
                    .Include(li => li.Shift)
                    .Include(li => li.WorkType)
                    .Include(li => li.EmploymentType)
                    .Include(li => li.Qualification)
                    .FirstOrDefaultAsync(li => li.Id == id); ;

                return jobPosts;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
