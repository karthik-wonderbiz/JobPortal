using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JobPortal.DTO.Employee.PersonalInfoDto;
using static JobPortal.DTO.Employee.SkillInfoDto;

namespace JobPortal.IServices.Employee
{
    public interface IPersonalInfoServices
    {
        Task<IEnumerable<GetPersonalInfoDto>> GetPersonalInfosAsync();
        Task<GetPersonalInfoDto> GetPersonalInfoAsync(long id);
        Task<GetPersonalInfoDto> CreatePersonalInfoAsync(CreatePersonalInfoDto createPersonalInfoDto);
        Task<GetPersonalInfoDto> UpdatePersonalInfoAsync(long id, UpdatePersonalInfoDto updatePersonalInfoDto);
        Task<bool> DeletePersonalInfoAsync(long id);
        Task<IEnumerable<GetPersonalInfoDto>> GetPersonalInfoByUserId(long userId);
    }
}
