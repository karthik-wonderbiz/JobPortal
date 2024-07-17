using JobPortal.Data;
using JobPortal.IRepository;
using JobPortal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Repository
{
    internal class UrlNameRepository : Repository<UrlName>, IUrlNameRepository
    {
        public UrlNameRepository(JobPortalDbContext dbcontext) : base(dbcontext)
        {

        }
    }
}
