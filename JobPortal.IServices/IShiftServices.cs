using JobPortal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.IServices
{
    public interface IShiftServices
    {
        public Task<Shift> GetShiftByIdAsync(long id);

        public Task<IEnumerable<Shift>> GetAllShiftsAsync();
        public Task<Shift> CreateShiftAsync(Shift shift);
        public Task<Shift> UpdateShiftAsync(long id, Shift shift);
        public Task<bool> DeleteShiftAsync(long id);
    }
}
