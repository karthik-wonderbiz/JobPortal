using JobPortal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JobPortal.DTO.UrlNameDto;

namespace JobPortal.IServices
{
    public interface IUrlNameServices
    {
        public Task<IEnumerable<GetUrlNameDto>> GetUrlNameAsync();
        public Task<GetUrlNameDto> GetUrlNameById(long id);
        public Task<GetUrlNameDto> CreateUrlNameAsync(CreateUrlNameDto createUrlNameDto);
        public Task<GetUrlNameDto> UpdateUrlNameAsync(long id, UpdateUrlNameDto updateUrlNameDto);
        public Task<bool> DeleteUrlNameAsync(long id);
    }
}
