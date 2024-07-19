using JobPortal.DTO;
using JobPortal.DTO.Employee;
using JobPortal.IRepository;
using JobPortal.IRepository.Employee;
using JobPortal.IServices.Employee;
using JobPortal.Model;
using JobPortal.Model.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JobPortal.DTO.Employee.WorkExperienceInfoDto;

namespace JobPortal.Services.Employee
{
    public class WorkExperienceInfoServices : IWorkExperienceInfoServices
    {
        private readonly IWorkExperienceInfoRepository _workExperienceInfoRepository;
        private readonly IUserRepository _userRepository;
        private readonly IWorkTypeRepository _workTypeRepository;
        private readonly IEmploymentTypeRepository _employmentTypeRepository;
        private readonly IDesignationRepository _designationRepository;

        public WorkExperienceInfoServices(
            IWorkExperienceInfoRepository workExperienceInfoRepository, 
            IUserRepository userRepository,
            IWorkTypeRepository workTypeRepository,
            IEmploymentTypeRepository employmentTypeRepository,
            IDesignationRepository designationRepository
            )
        {
            _workExperienceInfoRepository = workExperienceInfoRepository;
            _userRepository = userRepository;
            _workTypeRepository = workTypeRepository;
            _designationRepository = designationRepository;
            _employmentTypeRepository = employmentTypeRepository;
        }

        public async Task<GetWorkExperienceInfoDto> CreateWorkExperienceInfoAsync(CreateWorkExperienceInfoDto createWorkExperienceInfoDto)
        {
            try
            {
                var workExperienceInfo = await _workExperienceInfoRepository.CreateAsync(new WorkExperienceInfo()
                {
                    UserId = createWorkExperienceInfoDto.UserId,
                    WorkTypeId = createWorkExperienceInfoDto.WorkTypeId,
                    EmploymentTypeId = createWorkExperienceInfoDto.EmploymentTypeId,
                    DesignationId = createWorkExperienceInfoDto.DesignationId,
                    CompanyName = createWorkExperienceInfoDto.CompanyName,
                    StartDate = createWorkExperienceInfoDto.StartDate,
                    EndDate = createWorkExperienceInfoDto.EndDate,
                    SkillsUsed = createWorkExperienceInfoDto.SkillsUsed,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                });

                var user = await _userRepository.GetAsync(workExperienceInfo.UserId);
                var workType = await _workTypeRepository.GetAsync(workExperienceInfo.WorkTypeId);
                var employmentType = await _employmentTypeRepository.GetAsync(workExperienceInfo.EmploymentTypeId);
                var designation = await _designationRepository.GetAsync(workExperienceInfo.DesignationId);

                if (workType != null && user != null)
                {

                    var createdWorkExperienceInfo = new GetWorkExperienceInfoDto(
                        workExperienceInfo.Id,
                        user.Email,
                        workType.WorkTypeName,
                        employmentType.EmploymentTypeName,
                        designation.DesignationName,
                        workExperienceInfo.CompanyName,
                        workExperienceInfo.StartDate,
                        workExperienceInfo.EndDate,
                        workExperienceInfo.SkillsUsed
                    );

                    return createdWorkExperienceInfo;
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

        public async Task<GetWorkExperienceInfoDto> GetWorkExperienceInfoAsync(long id)
        {
            try
            {
                var workExperienceInfo = await _workExperienceInfoRepository.GetAsync(id);

                if (workExperienceInfo == null)
                {
                    throw new Exception($"Location Info not found for id : {id}");
                }

                var workExperienceInfoDto = new GetWorkExperienceInfoDto(
                    workExperienceInfo.Id,
                    workExperienceInfo.User.Email,
                    workExperienceInfo.WorkType.WorkTypeName,
                    workExperienceInfo.EmploymentType.EmploymentTypeName,
                    workExperienceInfo.Designation.DesignationName,
                    workExperienceInfo.CompanyName,
                    workExperienceInfo.StartDate,
                    workExperienceInfo.EndDate,
                    workExperienceInfo.SkillsUsed
                );

                return workExperienceInfoDto;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<GetWorkExperienceInfoDto>> GetWorkExperienceInfoByUserId(long userId)
        {
            try
            {
                var workExperienceInfos = await _workExperienceInfoRepository.GetByUserId(userId);

                var workExperienceInfoDtos = workExperienceInfos.Select(workExperienceInfo => new GetWorkExperienceInfoDto(
                    workExperienceInfo.Id,
                    workExperienceInfo.User.Email,
                    workExperienceInfo.WorkType.WorkTypeName,
                    workExperienceInfo.EmploymentType.EmploymentTypeName,
                    workExperienceInfo.Designation.DesignationName,
                    workExperienceInfo.CompanyName,
                    workExperienceInfo.StartDate,
                    workExperienceInfo.EndDate,
                    workExperienceInfo.SkillsUsed
                ));

                return workExperienceInfoDtos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<GetWorkExperienceInfoDto>> GetWorkExperienceInfosAsync()
        {
            try
            {
                var workExperienceInfos = await _workExperienceInfoRepository.GetAllAsync();

                var workExperienceInfoDtos = workExperienceInfos.Select(workExperienceInfo => new GetWorkExperienceInfoDto(
                    workExperienceInfo.Id,
                    workExperienceInfo.User.Email,
                    workExperienceInfo.WorkType.WorkTypeName,
                    workExperienceInfo.EmploymentType.EmploymentTypeName,
                    workExperienceInfo.Designation.DesignationName,
                    workExperienceInfo.CompanyName,
                    workExperienceInfo.StartDate,
                    workExperienceInfo.EndDate,
                    workExperienceInfo.SkillsUsed
                ));

                return workExperienceInfoDtos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GetWorkExperienceInfoDto> UpdateWorkExperienceInfoAsync(long id, UpdateWorkExperienceInfoDto updateWorkExperienceInfoDto)
        {
            try
            {
                var oldWorkExperienceInfo = await _workExperienceInfoRepository.GetAsync(id);
                if (oldWorkExperienceInfo == null)
                {
                    throw new Exception($"Location not found for id : {id}");
                }

                oldWorkExperienceInfo.UserId = updateWorkExperienceInfoDto.UserId;
                oldWorkExperienceInfo.WorkTypeId = updateWorkExperienceInfoDto.WorkTypeId;
                oldWorkExperienceInfo.EmploymentTypeId = updateWorkExperienceInfoDto.EmploymentTypeId;
                oldWorkExperienceInfo.DesignationId = updateWorkExperienceInfoDto.DesignationId;
                oldWorkExperienceInfo.CompanyName = updateWorkExperienceInfoDto.CompanyName;
                oldWorkExperienceInfo.StartDate = updateWorkExperienceInfoDto.StartDate;
                oldWorkExperienceInfo.EndDate = updateWorkExperienceInfoDto.EndDate;
                oldWorkExperienceInfo.SkillsUsed = updateWorkExperienceInfoDto.SkillsUsed;
                oldWorkExperienceInfo.UpdatedAt = DateTime.Now;

                await _workExperienceInfoRepository.UpdateAsync(oldWorkExperienceInfo);

                var user = await _userRepository.GetAsync(oldWorkExperienceInfo.UserId);
                var workType = await _workTypeRepository.GetAsync(oldWorkExperienceInfo.WorkTypeId);
                var employmentType = await _employmentTypeRepository.GetAsync(oldWorkExperienceInfo.EmploymentTypeId);
                var designation = await _designationRepository.GetAsync(oldWorkExperienceInfo.DesignationId);

                if (workType != null && user != null)
                {

                    var updatedWorkExperienceInfo = new GetWorkExperienceInfoDto(
                        oldWorkExperienceInfo.Id,
                        user.Email,
                        workType.WorkTypeName,
                        employmentType.EmploymentTypeName,
                        designation.DesignationName,
                        oldWorkExperienceInfo.CompanyName,
                        oldWorkExperienceInfo.StartDate,
                        oldWorkExperienceInfo.EndDate,
                        oldWorkExperienceInfo.SkillsUsed
                    );

                    return updatedWorkExperienceInfo;
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

        public async Task<bool> DeleteWorkExperienceInfoAsync(long id)
        {
            try
            {
                var workExperienceInfo = await _workExperienceInfoRepository.GetAsync(id);
                if (workExperienceInfo == null)
                {
                    throw new Exception($"Location Info not found for id : {id}");
                }

                var deleted = await _workExperienceInfoRepository.DeleteAsync(workExperienceInfo);
                return deleted;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
