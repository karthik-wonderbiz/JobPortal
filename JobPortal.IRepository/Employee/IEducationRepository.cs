using JobPortal.Model.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.IRepository.Employee
{
    public interface IEducationRepository : IRepository<Education>
    {
        Task<IEnumerable<Education>> GetEducationByUserId(long userId);
    }
}
