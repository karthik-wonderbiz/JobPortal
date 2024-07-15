using JobPortal.Data;
using JobPortal.IRepository;
using JobPortral.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Repository
{
    public class LanguageRepository : Repository<Language>, ILanguageRepository
    {
        public LanguageRepository(JobPortalDbContext dbcontext) : base(dbcontext)
        {

        }
    }
}
