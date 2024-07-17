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

            try
            {
                var state = await _repository.CreateAsync(new State()
                {
                    StateName = stateDto.StateName,
                    StateCode = stateDto.StateName.ToUpper().Substring(0, 3),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                });
                var createStateObject = new GetStateDto(state.Id, state.StateName, state.StateCode, state.IsActive);
                return createStateObject;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<bool> DeleteStateAsync(long id)
        {
            try
            {
                var oldState = await _repository.GetAsync(id);
                if (oldState == null)
                {
                    throw new Exception($"Object not found for id : {id}");
                }
                var deleteStateObject = await _repository.DeleteAsync(oldState);
                return deleteStateObject;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<GetStateDto>> GetAllStatesAsync()
        {
            try
            {
                var states = await _repository.GetAllAsync();

                var getAllStateObject = states.Select(state => new GetStateDto(state.Id, state.StateName, state.StateCode, state.IsActive));
                                
                return getAllStateObject;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<GetStateDto> GetStateByIdAsync(long id)
        {
            try
            {
                var state = await _repository.GetAsync(id);
                if (state == null)
                {
                    throw new Exception($"Object not found for id : {id}");
                    
                }
                var getStateObject = new GetStateDto(state.Id, state.StateName, state.StateCode, state.IsActive);
                return getStateObject;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<GetStateDto> UpdateStateAsync(long id, UpdateStateDto stateDto)
        {
            try
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

                var updateStateObject = new GetStateDto(oldState.Id, oldState.StateName, oldState.StateCode, oldState.IsActive);
                return updateStateObject;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
