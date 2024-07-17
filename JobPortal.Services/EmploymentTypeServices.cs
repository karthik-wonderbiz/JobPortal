using JobPortal.DTO;
using JobPortal.IRepository;
using JobPortal.IServices;
using JobPortal.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
                var empType = await _employmentTypeRepository.CreateAsync(new EmploymentType()
                {
                    EmploymentTypeName = employmentTypeDto.EmploymentTypeName,
                    EmploymentTypeCode = employmentTypeDto.EmploymentTypeName.ToUpper().Substring(0, 3),
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
            catch (DbUpdateException ex)
            {
                if (ex.InnerException?.Message.Contains("Cannot insert duplicate key row") == true ||
                    ex.InnerException?.Message.Contains("UNIQUE constraint failed") == true)
                {
                    throw new Exception("This input already exists.");
                }
                throw;
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

                if (empType == null)
                {
                    throw new Exception($"No Employment type Found with id: {id}");
                }

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

                var empTypeDto = empTypes.Select(empType => new GetEmploymentTypeDto(
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
                    throw new Exception($"No Employment Type found for id: {id}");
                }

                oldEmpType.EmploymentTypeName = employmentTypeDto.EmploymentTypeName;
                oldEmpType.EmploymentTypeCode = employmentTypeDto.EmploymentTypeName.ToUpper().Substring(0, 3);
                oldEmpType.IsActive = employmentTypeDto.IsActive;
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
            catch (DbUpdateException ex)
            {
                if (ex.InnerException?.Message.Contains("Cannot insert duplicate key row") == true ||
                    ex.InnerException?.Message.Contains("UNIQUE constraint failed") == true)
                {
                    throw new Exception("This input already exists.");
                }
                throw;
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
                    throw new Exception($"No Employment Type Found for id: {id}");
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
