using JobPortal.IRepository.Employee;
using JobPortal.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobPortal.IServices.Employee;
using JobPortal.DTO.Employee;
using static JobPortal.DTO.Employee.EducationDto;
using JobPortal.Model.Employee;

namespace JobPortal.Services.Employee
{
    public class EducationServices :IEducationServices
    {
        private readonly IEducationRepository _educationRepository;
        private readonly IUserRepository _userRepository;
        private readonly IQualificationRepository _qualificationRepository;

        public EducationServices(IEducationRepository educationRepository, IUserRepository userRepository, IQualificationRepository qualificationRepository)
        {
            _educationRepository = educationRepository;
            _qualificationRepository = qualificationRepository;
            _userRepository = userRepository;
        }

        public async Task<GetEducationDto> CreateEducationAsync(CreateEducationDto createEducationDto)
        {
            try
            {
                var education = await _educationRepository.CreateAsync(new Education()
                {
                    UserId = createEducationDto.UserId,
                    QualificationId = createEducationDto.QualificationId,
                    InstituteName = createEducationDto.InstituteName,
                    BoardOrUniversityName = createEducationDto.BoardOrUniversityName,
                    DegreeName = createEducationDto.DegreeName,
                    StartDate = createEducationDto.StartDate,
                    EndDate = createEducationDto.EndDate,
                    GradeOrPercentage = createEducationDto.GradeOrPercentage,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                });

                var user = await _userRepository.GetAsync(education.UserId);
                var quali = await _qualificationRepository.GetAsync(education.QualificationId);

                if (quali != null && user != null)
                {

                    var createdEducation = new GetEducationDto(
                        education.Id,
                        user.Email,
                        quali.QualificationName,
                        education.InstituteName,
                        education.BoardOrUniversityName,
                        education.DegreeName,
                        education.StartDate,
                        education.EndDate,
                        education.GradeOrPercentage      
                    );

                    return createdEducation;
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

        public async Task<bool> DeleteEducationAsync(long id)
        {
            try
            {
                var education = await _educationRepository.GetAsync(id);
                if (education == null)
                {
                    throw new Exception($"Education Details not found for id : {id}");
                }

                var deleted = await _educationRepository.DeleteAsync(education);
                return deleted;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<GetEducationDto>> GetEducationAsync()
        {
            try
            {
                var educations = await _educationRepository.GetAllAsync();

                var educationDtos = educations.Select(education => new GetEducationDto(
                    education.Id,
                    education.User.Email,
                    education.Qualification.QualificationName,
                    education.InstituteName,
                    education.BoardOrUniversityName,
                    education.DegreeName,
                    education.StartDate,
                    education.EndDate,
                    education.GradeOrPercentage
                ));

                return educationDtos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GetEducationDto> GetEducationAsync(long id)
        {
            try
            {
                var education = await _educationRepository.GetAsync(id);

                if (education == null)
                {
                    throw new Exception($"Education Details not found for id : {id}");
                }

                var educationDto = new GetEducationDto(
                    education.Id,
                    education.User.Email,
                    education.Qualification.QualificationName,
                    education.InstituteName,
                    education.BoardOrUniversityName,
                    education.DegreeName,
                    education.StartDate,
                    education.EndDate,
                    education.GradeOrPercentage
                );

                return educationDto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<GetEducationDto>> GetEducationByUserId(long userId)
        {

            try
            {
                var educations = await _educationRepository.GetEducationByUserId(userId);

                var educationDtos = educations.Select(education => new GetEducationDto(
                    education.Id,
                    education.User.Email,
                    education.Qualification.QualificationName,
                    education.InstituteName,
                    education.BoardOrUniversityName,
                    education.DegreeName,
                    education.StartDate,
                    education.EndDate,
                    education.GradeOrPercentage
                ));

                return educationDtos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GetEducationDto> UpdateEducationAsync(long id, UpdateEducationDto updateEducationDto)
        {
            try
            {
                var oldeducation = await _educationRepository.GetAsync(id);
                if (oldeducation == null)
                {
                    throw new Exception($"Education Details not found for id : {id}");
                }

                oldeducation.UserId = updateEducationDto.UserId;
                oldeducation.QualificationId = updateEducationDto.QualificationId;
                oldeducation.InstituteName = updateEducationDto.InstituteName;
                oldeducation.BoardOrUniversityName = updateEducationDto.BoardOrUniversityName;
                oldeducation.DegreeName = updateEducationDto.DegreeName;
                oldeducation.StartDate = updateEducationDto.StartDate;
                oldeducation.EndDate = updateEducationDto.EndDate;  
                oldeducation.GradeOrPercentage = updateEducationDto.GradeOrPercentage;
                oldeducation.UpdatedAt = DateTime.Now;

                await _educationRepository.UpdateAsync(oldeducation);

                var user = await _userRepository.GetAsync(oldeducation.UserId);
                var quali = await _qualificationRepository.GetAsync(oldeducation.QualificationId);

                if (quali != null && user != null)
                {

                    var updatededucation = new GetEducationDto(
                        oldeducation.Id,
                        user.Email,
                        quali.QualificationName,
                        oldeducation.InstituteName,
                        oldeducation.BoardOrUniversityName,
                        oldeducation.DegreeName,
                        oldeducation.StartDate,
                        oldeducation.EndDate,
                        oldeducation.GradeOrPercentage
                    );

                    return updatededucation;
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
