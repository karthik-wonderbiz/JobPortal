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
    public class WorkTypeServices : IWorkTypeServices
    {
        private readonly IWorkTypeRepository _workTypeRepository;

        public WorkTypeServices(IWorkTypeRepository workTypeRepository)
        {
            _workTypeRepository = workTypeRepository;
        }

        public async Task<WorkType> CreateWorkTypeAsync(WorkType workType)
        {
            workType.CreatedAt = DateTime.Now;
            workType.UpdatedAt = DateTime.Now;
            workType.WorkTypeCode = workType.WorkTypeCode != string.Empty ? workType.WorkTypeCode : workType.WorkTypeName.Substring(0, 3);
            return await _workTypeRepository.CreateAsync(workType);
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

        public async Task<IEnumerable<WorkType>> GetWorkTypeAsync()
        {
            var res = await _workTypeRepository.GetAllAsync();
            return res;
        }

        public async Task<WorkType> GetWorkTypeById(long id)
        {
            var res = await _workTypeRepository.GetAsync(id);
            return res;
        }

        public async Task<WorkType> UpdateWorkTypeAsync(long id, WorkType workType)
        {
            var oldWorkType = await _workTypeRepository.GetAsync(id);
            if(oldWorkType == null)
            {
                throw new Exception($"Object not found for id : {id}");
            }
            oldWorkType.WorkTypeName = workType.WorkTypeName; 
            oldWorkType.WorkTypeCode = workType.WorkTypeCode != string.Empty ? workType.WorkTypeCode : workType.WorkTypeName.Substring(0, 3);
            oldWorkType.IsActive = workType.IsActive;
            oldWorkType.UpdatedAt = DateTime.Now;
            
            var res = await _workTypeRepository.UpdateAsync(oldWorkType);
            return res;

        }
    }
}
