using JobPortal.Model.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.IRepository.Company
{
    public interface IContactPersonRepository : IRepository<ContactPerson>
    {
        Task<ContactPerson> GetContactPersonByCompanyId(long companyId);
    }
}
