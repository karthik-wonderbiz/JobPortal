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

        public async Task<Shift> CreateShiftAsync(Shift shift)
        {
            shift.CreatedAt = DateTime.Now;
            shift.UpdatedAt = DateTime.Now;
            shift.ShiftCode = shift.ShiftCode != string.Empty ? shift.ShiftCode : shift.ShiftName.Substring(0,1);
            return await _repository.CreateAsync(shift);
        }

        public async Task<bool> DeleteShiftAsync(long id)
        {
            var oldshift = await _repository.GetAsync(id);
            if (oldshift != null)
            {
                return await _repository.DeleteAsync(oldshift);
            }
            return false;
        }

        public async Task<IEnumerable<Shift>> GetAllShiftsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Shift> GetShiftByIdAsync(long id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<Shift> UpdateShiftAsync(long id, Shift shift)
        {
            var oldShift = await _repository.GetAsync(id);

            if (oldShift == null)
            {
                throw new Exception("Invalid");
            }
            oldShift.ShiftName = shift.ShiftName;
            oldShift.ShiftCode = shift.ShiftCode != string.Empty ? shift.ShiftCode : shift.ShiftName.Substring(0, 1);
            oldShift.UpdatedAt = DateTime.Now;
            oldShift.IsActive = shift.IsActive;

            await _repository.UpdateAsync(oldShift);
            return oldShift;
        }
    }
}
