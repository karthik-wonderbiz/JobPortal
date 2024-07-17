using JobPortal.Data;
using JobPortal.IRepository;
using JobPortal.IServices;
using JobPortal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JobPortal.DTO.LanguageDto;

namespace JobPortal.Services
{
    public class LanguageServices : ILanguageServices
    {
        private readonly ILanguageRepository _languageRepository;

        public LanguageServices(ILanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }

        public async Task<GetLanguageDto> CreateLanguageAsync(CreateLanguageDto createLanguageDto)
        {
            try
            {
                var language = await _languageRepository.CreateAsync(new Language() { LanguageName = createLanguageDto.LanguageName, LanguageCode = createLanguageDto.LanguageName.ToUpper().Substring(0, 3), CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now });
                var res = new GetLanguageDto(language.Id, language.LanguageName, language.LanguageCode, language.IsActive);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteLanguageAsync(long id)
        {
            var oldLanguage = await _languageRepository.GetAsync(id);
            if (oldLanguage == null)
            {
                throw new Exception($"No Language is found for id : {id}");
            }
            var res = await _languageRepository.DeleteAsync(oldLanguage);
            return res;
        }

        public async Task<IEnumerable<GetLanguageDto>> GetLanguageAsync()
        {    
            var language = await _languageRepository.GetAllAsync();
            var languageDto = language.Select(language => new GetLanguageDto(language.Id, language.LanguageName, language.LanguageCode, language.IsActive));
            return languageDto;   
        }

        public async Task<GetLanguageDto> GetLanguageById(long id)
        {
            try
            {
                var language = await _languageRepository.GetAsync(id);
                if (language == null)
                {
                    throw new Exception($"No Language is found for id : {id}");
                }
                var res = new GetLanguageDto(language.Id, language.LanguageName, language.LanguageCode, language.IsActive);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GetLanguageDto> UpdateLanguageAsync(long id, UpdateLanguageDto updateLanguageDto)
        {
            try
            {
                var oldLanguage = await _languageRepository.GetAsync(id);

                if (oldLanguage == null)
                {
                    throw new Exception($"Object not found for id : {id}");
                }

                oldLanguage.LanguageName = updateLanguageDto.LanguageName;
                oldLanguage.LanguageCode = updateLanguageDto.LanguageName.ToUpper().Substring(0, 3);
                oldLanguage.IsActive = updateLanguageDto.IsActive;

                await _languageRepository.UpdateAsync(oldLanguage);

                var res = new GetLanguageDto(oldLanguage.Id, oldLanguage.LanguageName, oldLanguage.LanguageCode, oldLanguage.IsActive);
                return res;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}

