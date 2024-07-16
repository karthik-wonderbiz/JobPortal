using JobPortal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.IServices
{
    public interface IEmploymentTypeServices
    {
        Task<IEnumerable<EmploymentType>> GetEmploymentTypesAsync();

        Task<EmploymentType> GetEmploymentTypeAsync(long id);

        Task<EmploymentType> CreateEmploymentTypeAsync(EmploymentType employmentType);

        Task<bool> DeleteEmploymentTypeAsync(long id);

        Task<EmploymentType> UpdateEmploymentTypeAsync(long id, EmploymentType employmentType);
    }
}
