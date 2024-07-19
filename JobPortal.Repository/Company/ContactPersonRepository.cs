using JobPortal.Data;
using JobPortal.IRepository.Company;
using JobPortal.Model.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Repository.Company
{
    public class ContactPersonRepository : Repository<ContactPerson>, IContactPersonRepository
    {
        public ContactPersonRepository(JobPortalDbContext dbcontext) : base(dbcontext)
        {
        }
    }
}
