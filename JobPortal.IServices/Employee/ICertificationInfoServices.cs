using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JobPortal.DTO.Employee.CertificationInfoDto;

namespace JobPortal.IServices.Employee
{
    public interface ICertificationInfoServices
    {
        Task<IEnumerable<GetCertificationInfoDto>> GetCertificationInfosAsync();

        Task<GetCertificationInfoDto> GetCertificationInfoAsync(long id);

        Task<GetCertificationInfoDto> CreateCertificationInfoAsync(CreateCertificationInfoDto createCertificationInfoDto);

        Task<GetCertificationInfoDto> UpdateCertificationInfoAsync(long id, UpdateCertificationInfoDto updateCertificationInfoDto);

        Task<bool> DeleteCertificationInfoAsync(long id);

        Task<IEnumerable<GetCertificationInfoDto>> GetCertificationInfoByUserId(long userId);
    }
}
