using JobPortal.Data;
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

        public async Task<GetStateDto> CreateStateAsync(CreateStateDto stateDto)
        {
            var state = await _repository.CreateAsync(new State() {
                StateName = stateDto.StateName,
                StateCode = stateDto.StateName.ToUpper().Substring(0, 3),
                CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now 
            });
            return new GetStateDto(state.Id, state.StateName, state.StateCode, state.IsActive);
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

        public async Task<IEnumerable<GetStateDto>> GetAllStatesAsync()
        {
            var states = await _repository.GetAllAsync();

            var stateDto = states.Select(state => new GetStateDto(state.Id, state.StateName, state.StateCode, state.IsActive));

            return stateDto;
        }

        public async Task<GetStateDto> GetStateByIdAsync(long id)
        {
            var state = await _repository.GetAsync(id);

            return new GetStateDto(state.Id, state.StateName, state.StateCode, state.IsActive);
        }

        public async Task<GetStateDto> UpdateStateAsync(long id, UpdateStateDto stateDto)
        {
            var oldState = await _repository.GetAsync(id);

            if (oldState == null)
            {
                throw new Exception($"Object not found for id : {id}");
            }

            oldState.StateName = stateDto.StateName;
            oldState.StateCode = stateDto.StateName.ToUpper().Substring(0, 3);
            oldState.IsActive = stateDto.IsActive;

            await _repository.UpdateAsync(oldState);

            return new GetStateDto(oldState.Id, oldState.StateName, oldState.StateCode, oldState.IsActive);
        }
    }
}
