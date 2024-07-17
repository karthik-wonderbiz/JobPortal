using JobPortal.DTO;
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

        public async Task<GetEmploymentTypeDto> CreateEmploymentTypeAsync(CreateEmploymentTypeDto employmentTypeDto)
        {
            try
            {
                //employmentType.EmploymentTypeCode = employmentType.EmploymentTypeCode != string.Empty ? employmentType.EmploymentTypeCode : employmentType.EmploymentTypeName.ToUpper().Substring(0, 2);

                //employmentType.UpdatedAt = DateTime.Now;
                //employmentType.CreatedAt = DateTime.Now;

                //return await _employmentTypeRepository.CreateAsync(employmentType);

                var empType = await _employmentTypeRepository.CreateAsync(new EmploymentType() { 
                    EmploymentTypeName = employmentTypeDto.EmploymentTypeName, 
                    EmploymentTypeCode = string.Empty, 
                    CreatedAt = DateTime.Now, 
                    UpdatedAt = DateTime.Now 
                });

                var res = new GetEmploymentTypeDto(
                    empType.Id, 
                    empType.EmploymentTypeName, 
                    empType.EmploymentTypeCode, 
                    empType.IsActive
                    );

                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<GetEmploymentTypeDto> GetEmploymentTypeAsync(long id)
        {
            try
            {
                var empType = await _employmentTypeRepository.GetAsync(id);

                var empTypeDto = new GetEmploymentTypeDto(
                    empType.Id,
                    empType.EmploymentTypeName,
                    empType.EmploymentTypeCode,
                    empType.IsActive
                    );

                return empTypeDto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<GetEmploymentTypeDto>> GetEmploymentTypesAsync()
        {
            try
            {
                var empTypes = await _employmentTypeRepository.GetAllAsync();

                var empTypeDto = empTypes.Select(empType =>  new GetEmploymentTypeDto(
                    empType.Id,
                    empType.EmploymentTypeName,
                    empType.EmploymentTypeCode,
                    empType.IsActive
                    ));

                return empTypeDto.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GetEmploymentTypeDto> UpdateEmploymentTypeAsync(long id, UpdateEmploymentTypeDto employmentTypeDto)
        {
            try
            {
                var oldEmpType = await _employmentTypeRepository.GetAsync(id);

                if (oldEmpType == null)
                {
                    throw new Exception($"No Employment Type found for id {id}");
                }

                oldEmpType.EmploymentTypeName = employmentTypeDto.EmploymentTypeName;
                oldEmpType.EmploymentTypeCode = employmentTypeDto.EmploymentTypeCode != string.Empty ? employmentTypeDto.EmploymentTypeCode : employmentTypeDto.EmploymentTypeName.ToUpper().Substring(0, 2);

                oldEmpType.UpdatedAt = DateTime.Now;

                var empType = await _employmentTypeRepository.UpdateAsync(oldEmpType);

                var newEmpTypeDto = new GetEmploymentTypeDto(
                    empType.Id,
                    empType.EmploymentTypeName,
                    empType.EmploymentTypeCode,
                    empType.IsActive
                    );

                return newEmpTypeDto;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> DeleteEmploymentTypeAsync(long id)
        {
            try
            {
                var empType = await _employmentTypeRepository.GetAsync(id);

                if (empType == null)
                {
                    throw new Exception($"No Employment Type Found for id {id}");
                }

                bool row = await _employmentTypeRepository.DeleteAsync(empType);

                return row;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
