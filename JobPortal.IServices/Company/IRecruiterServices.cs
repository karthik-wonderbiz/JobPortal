using JobPortal.Data;
using JobPortal.DTO.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.IServices.Company
{
    public interface IRecruiterServices
    {
        public Task<GetRecruiterDto> GetRecruiterByIdAsync(long id);
        public Task<IEnumerable<GetRecruiterDto>> GetAllRecruiterAsync();
        public Task<GetRecruiterDto> CreateRecruiterAsync(CreateRecruiterDto recruiterDto);
        public Task<GetRecruiterDto> UpdateRecruiterAsync(long id, UpdateRecruiterDto recruiterDto);
        public Task<bool> DeleteRecruiterAsync(long id);
    }
}
