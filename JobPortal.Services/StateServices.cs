using JobPortal.Data;
using JobPortal.DTO;
using JobPortal.IRepository;
using JobPortal.IServices;
using JobPortal.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal.Services
{
    public class StateServices : IStateServices
    {
        private readonly IStateRepository _stateRepository;

        public StateServices(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }

        public async Task<GetStateDto> CreateStateAsync(CreateStateDto stateDto)
        {
            try
            {
                var state = await _stateRepository.CreateAsync(new State()
                {
                    StateName = stateDto.StateName,
                    StateCode = stateDto.StateName.ToUpper().Substring(0, 3),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                });

                var res = new GetStateDto(state.Id, state.StateName, state.StateCode, state.IsActive);
                return res;
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

        public async Task<bool> DeleteStateAsync(long id)
        {
            try
            {
                var oldState = await _stateRepository.GetAsync(id);
                if (oldState == null)
                {
                    throw new Exception($"No State found for id : {id}");
                }

                var res = await _stateRepository.DeleteAsync(oldState);
                return res;
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
                var states = await _stateRepository.GetAllAsync();

                var stateDto = states.Select(state => new GetStateDto(
                    state.Id,
                    state.StateName,
                    state.StateCode,
                    state.IsActive
                ));

                return stateDto.ToList();
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
                var state = await _stateRepository.GetAsync(id);
                if (state == null)
                {
                    throw new Exception($"No State found for id : {id}");
                }

                var res = new GetStateDto(state.Id, state.StateName, state.StateCode, state.IsActive);
                return res;
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
                var oldState = await _stateRepository.GetAsync(id);
                if (oldState == null)
                {
                    throw new Exception($"No State found for id : {id}");
                }

                oldState.StateName = stateDto.StateName;
                oldState.StateCode = stateDto.StateName.ToUpper().Substring(0, 3);
                oldState.IsActive = stateDto.IsActive;
                oldState.UpdatedAt = DateTime.Now;

                await _stateRepository.UpdateAsync(oldState);

                var res = new GetStateDto(oldState.Id, oldState.StateName, oldState.StateCode, oldState.IsActive);
                return res;
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
