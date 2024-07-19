using JobPortal.Data;
using JobPortal.DTO.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.IServices.Company
{
    public interface IContactPersonServices
    {
        public Task<GetContactPersonDto> GetContactPersonByIdAsync(long id);
        public Task<IEnumerable<GetContactPersonDto>> GetAllContactPersonAsync();
        public Task<GetContactPersonDto> CreateContactPersonAsync(CreateContactPersonDto contactPersonDto);
        public Task<GetContactPersonDto> UpdateContactPersonAsync(long id, UpdateContactPersonDto contactPersonDto);
        public Task<bool> DeleteContactPersonAsync(long id);
    }
}
