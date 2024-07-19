using JobPortal.DTO.Employee;
using JobPortal.IRepository;
using JobPortal.IRepository.Employee;
using JobPortal.IServices.Employee;
using JobPortal.Model.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JobPortal.DTO.Employee.ProjectDto;
using static JobPortal.DTO.Employee.SkillInfoDto;

namespace JobPortal.Services.Employee
{
    public class ProjectServices : IProjectServices
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IUserRepository _userRepository;
        public ProjectServices(IProjectRepository projectRepository, IUserRepository userRepository)
        {
            _projectRepository = projectRepository;
            _userRepository = userRepository;
        }

        public async Task<GetProjectDto> CreateProjectAsync(CreateProjectDto createProjectDto)
        {
            try
            {
                var projects = await _projectRepository.CreateAsync(new Project()
                {
                    UserId = createProjectDto.UserId,
                    ProjectTitle = createProjectDto.ProjectTitle,
                    ProjectDescription = createProjectDto.ProjectDescription,   
                    ProjectUrl = createProjectDto.ProjectUrl,
                    Skills = createProjectDto.Skills,
                    ExpiryDate = createProjectDto.ExpiryDate,
                    Contributor = createProjectDto.Contributor,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                });

                var user = await _userRepository.GetAsync(projects.UserId);
               
                if (user != null)
                {

                    var createdProject = new GetProjectDto(
                        projects.Id,
                        user.Email,
                        projects.ProjectTitle,
                        projects.ProjectDescription,         
                        projects.Skills,
                        projects.ExpiryDate,
                        projects.Contributor,
                        projects.ProjectUrl
                    );

                    return createdProject;
                }
                else
                {
                    throw new Exception("Invalid User");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteProjectAsync(long id)
        {
            try
            {
                var projects = await _projectRepository.GetAsync(id);
                if (projects == null)
                {
                    throw new Exception($"Skill Info not found for id : {id}");
                }

                var deleted = await _projectRepository.DeleteAsync(projects);
                return deleted;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GetProjectDto> GetProjectAsync(long id)
        {
            try
            {
                var projects = await _projectRepository.GetAsync(id);

                if (projects == null)
                {
                    throw new Exception($"Project Details not found for id : {id}");
                }

                var projectsDto = new GetProjectDto(
                    projects.Id,
                    projects.User.Email,
                    projects.ProjectTitle,
                    projects.ProjectDescription,
                    projects.Skills,
                    projects.ExpiryDate,
                    projects.Contributor,
                    projects.ProjectUrl
                );

                return projectsDto;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<GetProjectDto>> GetProjectByUserId(long userId)
        {
            try
            {
                var projects = await _projectRepository.GetByUserId(userId);

                var projectDtos = projects.Select(projects => new GetProjectDto(
                    projects.Id,
                    projects.User.Email,
                    projects.ProjectTitle,
                    projects.ProjectDescription,
                    projects.Skills,
                    projects.ExpiryDate,
                    projects.Contributor,
                    projects.ProjectUrl

                ));

                return projectDtos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<GetProjectDto>> GetProjectsAsync()
        {
            try
            {
                var projects = await _projectRepository.GetAllAsync();

                var projectDtos = projects.Select(projects => new GetProjectDto(
                    projects.Id,
                    projects.User.Email,
                    projects.ProjectTitle,
                    projects.ProjectDescription,
                    projects.Skills,
                    projects.ExpiryDate,
                    projects.Contributor,
                    projects.ProjectUrl

                ));

                return projectDtos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GetProjectDto> UpdateProjectAsync(long id, UpdateProjectDto updateProjectDto)
        {
            try
            {
                var oldProject = await _projectRepository.GetAsync(id);
                if (oldProject == null)
                {
                    throw new Exception($"Project Details not found for id : {id}");
                }

                oldProject.UserId = updateProjectDto.UserId;
                oldProject.ProjectTitle = updateProjectDto.ProjectTitle;
                oldProject.ProjectDescription = updateProjectDto.ProjectDescription;
                oldProject.Skills = updateProjectDto.Skills;
                oldProject.ExpiryDate = updateProjectDto.ExpiryDate;
                oldProject.Contributor = updateProjectDto.Contributor;
                oldProject.ProjectUrl = updateProjectDto.ProjectUrl;
                oldProject.UpdatedAt = DateTime.Now;

                await _projectRepository.UpdateAsync(oldProject);

                var user = await _userRepository.GetAsync(oldProject.UserId);

                if (user != null)
                {

                    var updatedProject = new GetProjectDto(
                        oldProject.Id,
                        user.Email,
                        oldProject.ProjectTitle,
                        oldProject.ProjectDescription,
                        oldProject.Skills,
                        oldProject.ExpiryDate,
                        oldProject.Contributor,
                        oldProject.ProjectUrl

                    );

                    return updatedProject;
                }
                else
                {
                    throw new Exception("Invalid User");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
