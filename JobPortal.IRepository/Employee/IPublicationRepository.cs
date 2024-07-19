using JobPortal.Model;
using JobPortal.Model.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.IRepository.Employee
{
    public interface IPublicationRepository : IRepository<Publication>
    {
        Task<IEnumerable<Publication>> GetByUserId(long UserId);
    }
}
