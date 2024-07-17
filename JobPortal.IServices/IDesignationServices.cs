using JobPortal.Data;
using JobPortal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.IServices
{
    public interface IDesignationServices
    {
        public Task<GetDesignationDto> GetDesignationByIdAsync(long id);

        public Task<IEnumerable<GetDesignationDto>> GetAllDesignationsAsync();
        public Task<GetDesignationDto> CreateDesignationAsync(CreateDesignationDto designationDto);
        public Task<GetDesignationDto> UpdateDesignationAsync(long id, UpdateDesignationDto designationDto);
        public Task<bool> DeleteDesignationAsync(long id);
    }
}
