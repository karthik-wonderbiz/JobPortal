using JobPortal.IRepository.Employee;
using JobPortal.IRepository;
using JobPortal.IServices.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobPortal.DTO.Employee;
using static JobPortal.DTO.Employee.PersonalInfoDto;
using JobPortal.Model.Employee;

namespace JobPortal.Services.Employee
{
    public class PersonalInfoServices : IPersonalInfoServices
    {
        private readonly IPersonalInfoRepository _personalInfoRepository;
        private readonly IUserRepository _userRepository;
        private readonly IGenderRepository _genderRepository;

        public PersonalInfoServices(IPersonalInfoRepository personalInfoRepository, IUserRepository userRepository, IGenderRepository genderRepository)
        {
            _personalInfoRepository = personalInfoRepository;
            _userRepository = userRepository;
            _genderRepository = genderRepository;
        }

        public async Task<GetPersonalInfoDto> CreatePersonalInfoAsync(CreatePersonalInfoDto createPersonalInfoDto)
        {
            try
            {
                var personalInfo = await _personalInfoRepository.CreateAsync(new PersonalInfo()
                {
                    UserId = createPersonalInfoDto.UserId,
                    GenderId = createPersonalInfoDto.GenderId,
                    ProfilePic = createPersonalInfoDto.ProfilePic,
                    FirstName = createPersonalInfoDto.FirstName,
                    LastName = createPersonalInfoDto.LastName,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                });

                var user = await _userRepository.GetAsync(personalInfo.UserId);
                var gender = await _genderRepository.GetAsync(personalInfo.GenderId);

                if (gender != null && user != null)
                {

                    var createdPersonalInfo = new GetPersonalInfoDto(
                        personalInfo.Id,
                        user.Email,
                        gender.GenderName,
                        personalInfo.ProfilePic,
                        personalInfo.FirstName,
                        personalInfo.LastName
                    );

                    return createdPersonalInfo;
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

        public async Task<bool> DeletePersonalInfoAsync(long id)
        {
            try
            {
                var personalInfo = await _personalInfoRepository.GetAsync(id);
                if (personalInfo == null)
                {
                    throw new Exception($"Personal Info not found for id : {id}");
                }

                var deleted = await _personalInfoRepository.DeleteAsync(personalInfo);
                return deleted;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GetPersonalInfoDto> GetPersonalInfoAsync(long id)
        {
            try
            {
                var personalInfo = await _personalInfoRepository.GetAsync(id);

                if (personalInfo == null)
                {
                    throw new Exception($"Personal Info not found for id : {id}");
                }

                var personalInfoDto = new GetPersonalInfoDto(
                    personalInfo.Id,
                    personalInfo.User.Email,
                    personalInfo.Gender.GenderName,
                    personalInfo.ProfilePic,
                    personalInfo.FirstName,
                    personalInfo.LastName
                );

                return personalInfoDto;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<GetPersonalInfoDto>> GetPersonalInfosAsync()
        {
            try
            {
                var personalInfos = await _personalInfoRepository.GetAllAsync();

                var personalInfoDtos = personalInfos.Select(personalInfo => new GetPersonalInfoDto(
                    personalInfo.Id,
                    personalInfo.User.Email,
                    personalInfo.Gender.GenderName,
                    personalInfo.ProfilePic,
                    personalInfo.FirstName,
                    personalInfo.LastName
                ));

                return personalInfoDtos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<GetPersonalInfoDto>> GetPersonalInfoByUserId(long userId)
        {
            try
            {
                var personalInfos = await _personalInfoRepository.GetByUserId(userId);

                var personalInfoDtos = personalInfos.Select(personalInfo => new GetPersonalInfoDto(
                    personalInfo.Id,
                    personalInfo.User.Email,
                    personalInfo.Gender.GenderName,
                    personalInfo.ProfilePic,
                    personalInfo.FirstName,
                    personalInfo.LastName
                ));

                return personalInfoDtos;
            }
            catch (Exception)
            {
                throw;
            };
        }

        public async Task<GetPersonalInfoDto> UpdatePersonalInfoAsync(long id, UpdatePersonalInfoDto updatePersonalInfoDto)
        {
            try
            {
                var oldPersonalInfo = await _personalInfoRepository.GetAsync(id);
                if (oldPersonalInfo == null)
                {
                    throw new Exception($"Personal Information found for id : {id}");
                }

                oldPersonalInfo.UserId = updatePersonalInfoDto.UserId;
                oldPersonalInfo.GenderId = updatePersonalInfoDto.GenderId;
                oldPersonalInfo.ProfilePic = updatePersonalInfoDto.ProfilePic;
                oldPersonalInfo.FirstName = updatePersonalInfoDto.FirstName;
                oldPersonalInfo.LastName = updatePersonalInfoDto.LastName;
                oldPersonalInfo.UpdatedAt = DateTime.Now;

                await _personalInfoRepository.UpdateAsync(oldPersonalInfo);

                var user = await _userRepository.GetAsync(oldPersonalInfo.UserId);
                var gender = await _genderRepository.GetAsync(oldPersonalInfo.GenderId);

                if (gender != null && user != null)
                {

                    var updatedPersonalInfo = new GetPersonalInfoDto(
                        oldPersonalInfo.Id,
                        user.Email,
                        gender.GenderName,
                        oldPersonalInfo.ProfilePic,
                        oldPersonalInfo.FirstName,
                        oldPersonalInfo.LastName
                    );

                    return updatedPersonalInfo;
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
