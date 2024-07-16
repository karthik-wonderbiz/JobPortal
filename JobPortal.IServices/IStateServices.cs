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
        public Task<State> GetStateByIdAsync(long id);

        public Task<IEnumerable<State>> GetAllStatesAsync();
        public Task<State> CreateStateAsync(State State);
        public Task<State> UpdateStateAsync(long id, State State);
        public Task<bool> DeleteStateAsync(long id);
    }
}
