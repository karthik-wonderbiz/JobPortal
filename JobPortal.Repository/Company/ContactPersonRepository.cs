using JobPortal.Data;
using JobPortal.IRepository.Company;
using JobPortal.Model.Company;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Repository.Company
{
    public class ContactPersonRepository : Repository<ContactPerson>, IContactPersonRepository
    {
        private readonly JobPortalDbContext _dbContext;
        public ContactPersonRepository(JobPortalDbContext dbcontext) : base(dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task<ContactPerson> GetContactPersonByCompanyId(long companyId)
        {
            try
            {
                var contactPerson = await _dbContext.contactPersons
                    .Include(li => li.CompanyInfo)
                    .FirstOrDefaultAsync(li => li.CompanyId == companyId);
                return contactPerson;

            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve contact person by company id.", ex);
            }
        }
    }
}
