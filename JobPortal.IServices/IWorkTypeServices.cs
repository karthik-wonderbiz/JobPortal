using JobPortal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.IServices
{
    public interface IWorkTypeServices
    {
        public Task<IEnumerable<WorkType>> GetWorkTypeAsync();
        public Task<WorkType> GetWorkTypeById(long id);
        public Task<WorkType> CreateWorkTypeAsync(WorkType workType);
        public Task<WorkType> UpdateWorkTypeAsync(long id, WorkType workType);
        public Task<bool> DeleteWorkTypeAsync(long id);
    }
}
