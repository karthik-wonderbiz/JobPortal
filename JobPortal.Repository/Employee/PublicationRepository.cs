
using JobPortal.Data;
using JobPortal.IRepository.Employee;
using JobPortal.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Repository.Employee
{
    public class PublicationRepository : Repository<Publication>, IPublicationRepository
    {
        private readonly JobPortalDbContext _dbcontext;

        public PublicationRepository(JobPortalDbContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<IEnumerable<Publication>> GetByUserId(long UserId)
        {
            try
            {
                var publications = await _dbcontext.publications
                    .Include(li => li.User)
                    .Where(li => li.UserId == UserId)
                    .ToListAsync();

                return publications;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Publication>> GetAllAsync()
        {
            try
            {
                var publications = await _dbcontext.publications
                    .Include(li => li.User)
                    .ToListAsync();

                return publications;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Publication> GetAsync(long id)
        {
            try
            {
                var publication = await _dbcontext.publications
                    .Include(li => li.User)
                    .FirstOrDefaultAsync(li => li.Id == id);

                return publication;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
