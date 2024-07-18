using JobPortal.Data;
using JobPortal.DTO;
using JobPortal.DTO.Employee;
using JobPortal.IRepository;
using JobPortal.IRepository.Employee;
using JobPortal.IServices.Employee;
using JobPortal.Model;
using JobPortal.Model.Employee;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JobPortal.DTO.Employee.LanguageInfoDto;
using static JobPortal.DTO.Employee.SkillInfoDto;
using static JobPortal.DTO.LanguageDto;

namespace JobPortal.Services.Employee
{
    public class LanguageInfoServices : ILanguageInfoServices
    {
        private readonly ILanguageInfoRepository _languageInfoRepository;
        private readonly ILanguageRepository _languageRepository;
        private readonly IUserRepository _userRepository;

        public LanguageInfoServices(ILanguageInfoRepository languageInfoRepository, IUserRepository userRepository, ILanguageRepository languageRepository)
        {
            _languageInfoRepository = languageInfoRepository;
            _userRepository = userRepository;
            _languageRepository = languageRepository;
        }

        public async Task<GetLanguageInfoDto> CreateLanguageInfoAsync(CreateLanguageInfoDto createLanguageInfoDto)
        {
            try
            {
                var languageInfo = await _languageInfoRepository.CreateAsync(new LanguageInfo()
                {
                    UserId = createLanguageInfoDto.UserId,
                    LanguageId = createLanguageInfoDto.LanguageID,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    
                });
                var user = await _userRepository.GetAsync(languageInfo.UserId);
                var language = await _languageRepository.GetAsync(languageInfo.LanguageId);
                if (user != null &&
                    language != null)
                {

                    var res = new GetLanguageInfoDto(languageInfo.Id, user.Email, language.LanguageName);
                    
                    return res;
                }
                else
                {
                    throw new Exception("Ivalid user id");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteLanguageInfoAsync(long id)
        {
            try
            {
                var oldLanguageInfo = await _languageInfoRepository.GetAsync(id);
                if (oldLanguageInfo == null)
                {
                    throw new Exception($"No Language found for id : {id}");
                }

                var res = await _languageInfoRepository.DeleteAsync(oldLanguageInfo);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<GetLanguageInfoDto>> GetLanguageInfoAsync()
        {
            try
            {
                var languageInfos = await _languageInfoRepository.GetAllAsync();
                var languageInfoDto = languageInfos.Select(languageInfo => new GetLanguageInfoDto(languageInfo.Id, languageInfo.Language.LanguageName, languageInfo.User.Email));
                return languageInfoDto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GetLanguageInfoDto> GetLanguageInfoById(long id)
        {
            try
            {
                var languageInfo = await _languageInfoRepository.GetAsync(id);
                if (languageInfo == null)
                {
                    throw new Exception($"No Language found for id : {id}");
                }

                var res = new GetLanguageInfoDto(languageInfo.Id, languageInfo.User.Email, languageInfo.Language.LanguageName);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<GetLanguageInfoDto>> GetLanguageInfoByUserId(long userId)
        {
            try
            {
                var languageInfo = await _languageInfoRepository.GetLanguageInfoByUserId(userId);

                var languageInfoDtos = languageInfo.Select(languageInfo => new GetLanguageInfoDto(
                    languageInfo.Id,
                    languageInfo.User.Email,
                    languageInfo.Language.LanguageName
                ));

                return languageInfoDtos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GetLanguageInfoDto> UpdateLanguageInfoAsync(long id, UpdateLanguageInfoDto updateLanguageInfoDto)
        {
            try
            {
                var oldLanguageInfo = await _languageInfoRepository.GetAsync(id);
                if (oldLanguageInfo == null)
                {
                    throw new Exception($"No Language found for id : {id}");
                }

                oldLanguageInfo.UserId = updateLanguageInfoDto.UserId;
                oldLanguageInfo.LanguageId = updateLanguageInfoDto.LanguageID;
                oldLanguageInfo.UpdatedAt = DateTime.Now;

                await _languageInfoRepository.UpdateAsync(oldLanguageInfo);

                var user = await _userRepository.GetAsync(oldLanguageInfo.UserId);
                var language = await _languageRepository.GetAsync(oldLanguageInfo.LanguageId);

                var res = new GetLanguageInfoDto(oldLanguageInfo.Id, user.Email, language.LanguageName);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
