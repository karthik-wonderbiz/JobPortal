using JobPortal.Data;
using JobPortal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.IServices
{
    public interface IStateServices
    {
        public Task<GetStateDto> GetStateByIdAsync(long id);

        public Task<IEnumerable<GetStateDto>> GetAllStatesAsync();
        public Task<GetStateDto> CreateStateAsync(CreateStateDto stateDto);
        public Task<GetStateDto> UpdateStateAsync(long id, UpdateStateDto stateDto);
        public Task<bool> DeleteStateAsync(long id);
    }
}
