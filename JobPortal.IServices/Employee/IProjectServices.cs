using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JobPortal.DTO.Employee.ProjectDto;

namespace JobPortal.IServices.Employee
{
    public interface IProjectServices
    {
        Task<IEnumerable<GetProjectDto>> GetProjectsAsync();
        Task<GetProjectDto> GetProjectAsync(long id);
        Task<GetProjectDto> CreateProjectAsync(CreateProjectDto createProjectDto);
        Task<GetProjectDto> UpdateProjectAsync(long id, UpdateProjectDto updateProjectDto);
        Task<bool> DeleteProjectAsync(long id);
        Task<IEnumerable<GetProjectDto>> GetProjectByUserId(long userId);
    }
}
