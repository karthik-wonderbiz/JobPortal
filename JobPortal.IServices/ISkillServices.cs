using JobPortal.DTO;
using JobPortal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JobPortal.DTO.SkillDto;

namespace JobPortal.IServices
{
    public interface ISkillServices
    {
        Task<IEnumerable<GetSkillDto>> GetSkillsAsync();

        Task<GetSkillDto> GetSkillAsync(long id);

        Task<GetSkillDto> CreateSkillAsync(CreateSkillDto createSkillDto);
        
        Task<GetSkillDto> UpdateSkillAsync(long id, UpdateSkillDto updateSkillDto);
        
        Task<bool> DeleteSkillAsync(long id);
    }
}
