using JobPortal.DTO;
using JobPortal.IRepository;
using JobPortal.IServices;
using JobPortal.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static JobPortal.DTO.WorkTypeDto;

namespace JobPortal.Services
{
    public class WorkTypeServices : IWorkTypeServices
    {
        private readonly IWorkTypeRepository _workTypeRepository;

        public WorkTypeServices(IWorkTypeRepository workTypeRepository)
        {
            _workTypeRepository = workTypeRepository;
        }

        public async Task<GetWorkTypeDto> CreateWorkTypeAsync(CreateWorkTypeDto createWorkTypeDto)
        {
            try
            {
                var workType = await _workTypeRepository.CreateAsync(new WorkType()
                {
                    WorkTypeName = createWorkTypeDto.WorkTypeName,
                    WorkTypeCode = createWorkTypeDto.WorkTypeName.ToUpper().Substring(0, 3),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                });

                var createdWorkType = new GetWorkTypeDto(workType.Id, workType.WorkTypeName, workType.WorkTypeCode, workType.IsActive);
                return createdWorkType;
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

        public async Task<bool> DeleteWorkTypeAsync(long id)
        {
            try
            {
                var workType = await _workTypeRepository.GetAsync(id);
                if (workType == null)
                {
                    throw new Exception($"Work Type not found for id : {id}");
                }

                var deleted = await _workTypeRepository.DeleteAsync(workType);
                return deleted;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<GetWorkTypeDto>> GetWorkTypeAsync()
        {
            try
            {
                var workTypes = await _workTypeRepository.GetAllAsync();

                var workTypeDto = workTypes.Select(workType => new GetWorkTypeDto(
                    workType.Id,
                    workType.WorkTypeName,
                    workType.WorkTypeCode,
                    workType.IsActive
                ));

                return workTypeDto.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GetWorkTypeDto> GetWorkTypeById(long id)
        {
            try
            {
                var workType = await _workTypeRepository.GetAsync(id);
                if (workType == null)
                {
                    throw new Exception($"Work Type not found for id : {id}");
                }

                var workTypeData = new GetWorkTypeDto(workType.Id, workType.WorkTypeName, workType.WorkTypeCode, workType.IsActive);
                return workTypeData;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GetWorkTypeDto> UpdateWorkTypeAsync(long id, UpdateWorkTypeDto updateWorkTypeDto)
        {
            try
            {
                var oldWorkType = await _workTypeRepository.GetAsync(id);
                if (oldWorkType == null)
                {
                    throw new Exception($"Work Type not found for id : {id}");
                }

                oldWorkType.WorkTypeName = updateWorkTypeDto.WorkTypeName;
                oldWorkType.WorkTypeCode = updateWorkTypeDto.WorkTypeName.ToUpper().Substring(0, 3);
                oldWorkType.IsActive = updateWorkTypeDto.IsActive;
                oldWorkType.UpdatedAt = DateTime.Now;

                await _workTypeRepository.UpdateAsync(oldWorkType);

                var updatedWorkType = new GetWorkTypeDto(oldWorkType.Id, oldWorkType.WorkTypeName, oldWorkType.WorkTypeCode, oldWorkType.IsActive);
                return updatedWorkType;
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
    }
}
