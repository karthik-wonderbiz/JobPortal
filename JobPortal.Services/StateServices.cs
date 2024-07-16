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
    public class StateServices : IStateServices
    {
        private readonly IStateRepository _repository;
        public StateServices(IStateRepository repository)
        {
            _repository = repository;
        }

        public async Task<State> CreateStateAsync(State State)
        {
            return await _repository.CreateAsync(State);
        }

        public async Task<bool> DeleteStateAsync(long id)
        {
            var oldState = await _repository.GetAsync(id);
            if (oldState != null)
            {
                return await _repository.DeleteAsync(oldState);
            }
            return false;
        }

        public async Task<IEnumerable<State>> GetAllStatesAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<State> GetStateByIdAsync(long id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<State> UpdateStateAsync(long id, State State)
        {
            var oldState = await _repository.GetAsync(id);

            if (oldState != null)
            {
                oldState.StateName = State.StateName;
                oldState.UpdatedAt = DateTime.Now;

                await _repository.UpdateAsync(oldState);
            }
            return oldState;
        }
    }
}
