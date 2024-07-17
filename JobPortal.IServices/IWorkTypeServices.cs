using JobPortal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JobPortal.DTO.WorkTypeDto;

namespace JobPortal.IServices
{
    public interface IWorkTypeServices
    {
        public Task<IEnumerable<GetWorkTypeDto>> GetWorkTypeAsync();
        public Task<GetWorkTypeDto> GetWorkTypeById(long id);
        public Task<GetWorkTypeDto> CreateWorkTypeAsync(CreateWorkTypeDto createWorkTypeDto);
        public Task<GetWorkTypeDto> UpdateWorkTypeAsync(long id, UpdateWorkTypeDto updateWorkTypeDto);
        public Task<bool> DeleteWorkTypeAsync(long id);
    }
}
