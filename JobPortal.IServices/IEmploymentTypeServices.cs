using JobPortal.DTO;
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
        Task<IEnumerable<GetEmploymentTypeDto>> GetEmploymentTypesAsync();

        Task<GetEmploymentTypeDto> GetEmploymentTypeAsync(long id);

        Task<GetEmploymentTypeDto> CreateEmploymentTypeAsync(CreateEmploymentTypeDto employmentTypeDto);

        Task<bool> DeleteEmploymentTypeAsync(long id);

        Task<GetEmploymentTypeDto> UpdateEmploymentTypeAsync(long id, UpdateEmploymentTypeDto employmentTypeDto);
    }
}
