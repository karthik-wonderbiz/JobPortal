using JobPortal.IRepository;
using JobPortal.IServices;
using JobPortal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                var workType = await _workTypeRepository.CreateAsync(new WorkType() { WorkTypeName = createWorkTypeDto.WorkTypeName, WorkTypeCode = createWorkTypeDto.WorkTypeName.ToUpper().Substring(0, 3), CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now });
                var res = new GetWorkTypeDto(workType.Id, workType.WorkTypeName, workType.WorkTypeCode, workType.IsActive);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteWorkTypeAsync(long id)
        {
            var oldWorkType = await _workTypeRepository.GetAsync(id);
            if(oldWorkType == null)
            {
                throw new Exception($"No Work Type found for id : {id}");
            }
            var res = await _workTypeRepository.DeleteAsync(oldWorkType);
            return res;
        }

        public async Task<IEnumerable<GetWorkTypeDto>> GetWorkTypeAsync()
        {
            var workType = await _workTypeRepository.GetAllAsync();
            var workTypeDto = workType.Select(workType => new GetWorkTypeDto(workType.Id, workType.WorkTypeName, workType.WorkTypeCode, workType.IsActive));
            return workTypeDto;
        }

        public async Task<GetWorkTypeDto> GetWorkTypeById(long id)
        {
            try
            {
                var workType = await _workTypeRepository.GetAsync(id);
                if (workType == null)
                {
                    throw new Exception($"Object not found for id : {id}");
                }
                var res = new GetWorkTypeDto(workType.Id, workType.WorkTypeName, workType.WorkTypeCode, workType.IsActive);
                return res;
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
                    throw new Exception($"Object not found for id : {id}");
                }

                oldWorkType.WorkTypeName = updateWorkTypeDto.WorkTypeName;
                oldWorkType.WorkTypeCode = updateWorkTypeDto.WorkTypeName.ToUpper().Substring(0, 3);
                oldWorkType.IsActive = updateWorkTypeDto.IsActive;

                await _workTypeRepository.UpdateAsync(oldWorkType);

                var res = new GetWorkTypeDto(oldWorkType.Id, oldWorkType.WorkTypeName, oldWorkType.WorkTypeCode, oldWorkType.IsActive);
                return res;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
