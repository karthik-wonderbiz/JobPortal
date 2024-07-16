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
    public class ShiftServices : IShiftServices
    {
        private readonly IShiftRepository _repository;
        public ShiftServices(IShiftRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetShiftDto> CreateShiftAsync(CreateShiftDto shiftDto)
        {
            var shift = await _repository.CreateAsync(new Shift()
            {
                ShiftName = shiftDto.ShiftName,
                ShiftCode = shiftDto.ShiftName.ToUpper().Substring(0, 1),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            });
            return new GetShiftDto(shift.Id, shift.ShiftName, shift.ShiftCode, shift.IsActive);
        }

        public async Task<bool> DeleteShiftAsync(long id)
        {
            var oldShift = await _repository.GetAsync(id);
            if (oldShift != null)
            {
                return await _repository.DeleteAsync(oldShift);
            }
            return false;
        }

        public async Task<IEnumerable<GetShiftDto>> GetAllShiftsAsync()
        {
            var shifts = await _repository.GetAllAsync();

            var shiftDto = shifts.Select(shift => new GetShiftDto(shift.Id, shift.ShiftName, shift.ShiftCode, shift.IsActive));

            return shiftDto;
        }

        public async Task<GetShiftDto> GetShiftByIdAsync(long id)
        {
            var shift = await _repository.GetAsync(id);

            return new GetShiftDto(shift.Id, shift.ShiftName, shift.ShiftCode, shift.IsActive);
        }

        public async Task<GetShiftDto> UpdateShiftAsync(long id, UpdateShiftDto shiftDto)
        {
            var oldShift = await _repository.GetAsync(id);

            if (oldShift == null)
            {
                throw new Exception($"Object not found for id : {id}");
            }

            oldShift.ShiftName = shiftDto.ShiftName;
            oldShift.ShiftCode = shiftDto.ShiftName.ToUpper().Substring(0, 1);
            oldShift.IsActive = shiftDto.IsActive;

            await _repository.UpdateAsync(oldShift);

            return new GetShiftDto(oldShift.Id, oldShift.ShiftName, oldShift.ShiftCode, oldShift.IsActive);
        }
    }
}
