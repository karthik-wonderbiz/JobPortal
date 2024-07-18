using JobPortal.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JobPortal.DTO.Employee.SkillInfoDto;

namespace JobPortal.IServices.Employee
{
    public interface ISkillInfoServices
    {
        Task<IEnumerable<GetSkillInfoDto>> GetSkillInfosAsync();

        Task<GetSkillInfoDto> GetSkillInfoAsync(long id);

        Task<GetSkillInfoDto> CreateSkillInfoAsync(CreateSkillInfoDto createSkillInfoDto);

        Task<GetSkillInfoDto> UpdateSkillInfoAsync(long id, UpdateSkillInfoDto updateSkillInfoDto);

        Task<bool> DeleteSkillInfoAsync(long id);

        Task<IEnumerable<GetSkillInfoDto>> GetSkillInfoByUserId(long userId);
    }
}
