using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JobPortal.DTO.Employee.WorkExperienceInfoDto;

namespace JobPortal.IServices.Employee
{
    public interface IWorkExperienceInfoServices
    {
        Task<IEnumerable<GetWorkExperienceInfoDto>> GetWorkExperienceInfosAsync();

        Task<GetWorkExperienceInfoDto> GetWorkExperienceInfoAsync(long id);

        Task<GetWorkExperienceInfoDto> CreateWorkExperienceInfoAsync(CreateWorkExperienceInfoDto createWorkExperienceInfoDto);

        Task<GetWorkExperienceInfoDto> UpdateWorkExperienceInfoAsync(long id, UpdateWorkExperienceInfoDto updateWorkExperienceInfoDto);

        Task<bool> DeleteWorkExperienceInfoAsync(long id);

        Task<IEnumerable<GetWorkExperienceInfoDto>> GetWorkExperienceInfoByUserId(long userId);
    }
}
