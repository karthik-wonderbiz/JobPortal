using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JobPortal.DTO.Employee.LocationInfoDto;

namespace JobPortal.IServices.Employee
{
    public interface ILocationInfoServices
    {
        Task<IEnumerable<GetLocationInfoDto>> GetLocationInfosAsync();

        Task<GetLocationInfoDto> GetLocationInfoAsync(long id);

        Task<GetLocationInfoDto> CreateLocationInfoAsync(CreateLocationInfoDto createLocationInfoDto);

        Task<GetLocationInfoDto> UpdateLocationInfoAsync(long id, UpdateLocationInfoDto updateLocationInfoDto);

        Task<bool> DeleteLocationInfoAsync(long id);

        Task<IEnumerable<GetLocationInfoDto>> GetLocationInfoByUserId(long userId);
    }
}
