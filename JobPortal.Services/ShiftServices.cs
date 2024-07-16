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

        public async Task<Shift> CreateShiftAsync(Shift Shift)
        {
            Shift.CreatedAt = DateTime.Now;
            Shift.UpdatedAt = DateTime.Now;
            Shift.ShiftCode = Shift.ShiftCode.Substring(0);
            return await _repository.CreateAsync(Shift);
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

        public async Task<Shift> UpdateShiftAsync(long id, Shift Shift)
        {
            var oldShift = await _repository.GetAsync(id);

            if (oldShift == null)
            {
                throw new Exception("Invalid");
            }
            oldShift.ShiftName = Shift.ShiftName;
            oldShift.ShiftCode = Shift.ShiftCode;
            oldShift.UpdatedAt = DateTime.Now;
            oldShift.IsActive = Shift.IsActive;

            await _repository.UpdateAsync(oldShift);
            return oldShift;
        }
    }
}
