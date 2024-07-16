using JobPortal.IRepository;
using JobPortal.IServices;
using JobPortal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Services
{
    public class EmploymentTypeServices : IEmploymentTypeServices
    {
        private readonly IEmploymentTypeRepository _employmentTypeRepository;

        public EmploymentTypeServices(IEmploymentTypeRepository employmentTypeRepository)
        {
            _employmentTypeRepository = employmentTypeRepository;
        }

        public async Task<EmploymentType> CreateEmploymentTypeAsync(EmploymentType employmentType)
        {
            employmentType.CreatedAt = DateTime.Now;
            employmentType.UpdatedAt = DateTime.Now;
            employmentType.EmploymentTypeCode = employmentType.EmploymentTypeName.ToUpper().Substring(0, 2);

            return await _employmentTypeRepository.CreateAsync(employmentType);
        }

        public async Task<bool> DeleteEmploymentTypeAsync(long id)
        {
            var empType = await _employmentTypeRepository.GetAsync(id);

            if (empType == null)
            {
                throw new Exception($"No EmploymentType found for id {id}");
            }

            bool row = await _employmentTypeRepository.DeleteAsync(empType);

            return row;
        }

        public async Task<EmploymentType> GetEmploymentTypeAsync(long id)
        {
            return await _employmentTypeRepository.GetAsync(id);
        }

        public async Task<IEnumerable<EmploymentType>> GetEmploymentTypesAsync()
        {
            return await _employmentTypeRepository.GetAllAsync();
        }

        public async Task<EmploymentType> UpdateEmploymentTypeAsync(long id, EmploymentType employmentType)
        {
            var empType = await _employmentTypeRepository.GetAsync(id);

            if(empType == null)
            {
                throw new Exception($"No EmploymentType found for id {id}");
            }

            empType.EmploymentTypeName = employmentType.EmploymentTypeName;
            empType.EmploymentTypeCode = employmentType.EmploymentTypeCode;

            empType.UpdatedAt = DateTime.Now;

            await _employmentTypeRepository.UpdateAsync(empType);

            return empType;
        }
    }
}
