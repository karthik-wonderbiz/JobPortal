using JobPortal.Data;
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
        public Task<GetShiftDto> GetShiftByIdAsync(long id);

        public Task<IEnumerable<GetShiftDto>> GetAllShiftsAsync();
        public Task<GetShiftDto> CreateShiftAsync(CreateShiftDto shiftDto);
        public Task<GetShiftDto> UpdateShiftAsync(long id, UpdateShiftDto shiftDto);
        public Task<bool> DeleteShiftAsync(long id);
    }
}
