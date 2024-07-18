using JobPortal.Data;
using JobPortal.IRepository.Employee;
using JobPortal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Repository.Employee
{
    public class PublicationRepository : Repository<Publication>, IPublicationRepository
    {
        public PublicationRepository(JobPortalDbContext dbcontext) : base(dbcontext)
        {
        }
    }
}
