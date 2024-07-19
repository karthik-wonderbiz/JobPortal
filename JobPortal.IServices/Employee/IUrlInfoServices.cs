using JobPortal.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JobPortal.DTO.Employee.UrlInfoDto;

namespace JobPortal.IServices.Employee
{
    public interface IUrlInfoServices
    {
        Task<IEnumerable<GetUrlInfoDto>> GetUrlInfosAsync();

        Task<GetUrlInfoDto> GetUrlInfoAsync(long id);

        Task<GetUrlInfoDto> CreateUrlInfoAsync(CreateUrlInfoDto createUrlInfoDto);

        Task<GetUrlInfoDto> UpdateUrlInfoAsync(long id, UpdateUrlInfoDto updateUrlInfoDto);

        Task<bool> DeleteUrlInfoAsync(long id);

        Task<IEnumerable<GetUrlInfoDto>> GetUrlInfoByUserId(long userId);
    }
}
