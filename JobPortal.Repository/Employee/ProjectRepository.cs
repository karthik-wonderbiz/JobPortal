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
    public class ProjectRepository : Repository<Project>,IProjectRepository
    {
        private readonly JobPortalDbContext _dbcontext;

        public ProjectRepository(JobPortalDbContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }

        async Task<IEnumerable<Project>> IProjectRepository.GetByUserId(long userId)
        {
            try
            {
                var project = await _dbcontext.projects
                    .Include(li => li.User)
                    .Where(li => li.UserId == userId)
                    .ToListAsync();

                return project;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Project>> GetAllAsync()
        {
            try
            {
                var project = await _dbcontext.projects
                    .Include(li => li.User)
                    .ToListAsync();

                return project;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Project> GetAsync(long id)
        {
            try
            {
                var project = await _dbcontext.projects
                    .Include(li => li.User)
                    .FirstOrDefaultAsync(li => li.Id == id);

                return project;
            }
            catch (Exception)
            {
                throw;
            }
        }

        
    }
}
