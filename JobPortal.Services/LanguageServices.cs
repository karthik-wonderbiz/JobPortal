using JobPortal.IRepository;
using JobPortal.IServices;
using JobPortal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Services
{
    public class LanguageServices : ILanguageServices
    {
        private readonly ILanguageRepository _languageRepository;

        public LanguageServices(ILanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }

        public async Task<Language> CreateLanguageAsync(Language language)
        {
            language.CreatedAt = DateTime.Now;
            language.UpdatedAt = DateTime.Now;
            language.LanguageCode = language.LanguageCode != string.Empty ? language.LanguageCode : language.LanguageName.Substring(0, 3);
            return await _languageRepository.CreateAsync(language);
        }

        public async Task<bool> DeleteLanguageAsync(long id)
        {
            var oldLanguage = await _languageRepository.GetAsync(id);
            if (oldLanguage == null) {
                throw new Exception($"No Language is found for id : {id}");
            }
            var res = await _languageRepository.DeleteAsync(oldLanguage);
            return res;
        }

        public async Task<IEnumerable<Language>> GetLanguageAsync()
        {
            return await _languageRepository.GetAllAsync();
        }

        public async Task<Language> GetLanguageById(long id)
        {
            return await _languageRepository.GetAsync(id);
        }

        public async Task<Language> UpdateLanguageAsync(long id, Language language)
        {
            var oldLanguage = await _languageRepository.GetAsync(id);
            if (oldLanguage == null) {
                throw new Exception($"Object not found with id : {id}");  
            }
            oldLanguage.LanguageName = language.LanguageName;
            oldLanguage.LanguageCode = language.LanguageCode != string.Empty ? language.LanguageCode : language.LanguageName.Substring(0, 3);
            oldLanguage.IsActive = language.IsActive;
            oldLanguage.UpdatedAt = DateTime.Now;
            var res = await _languageRepository.UpdateAsync(oldLanguage);
            return res;
        }
    }
}
