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
            return await _languageRepository.CreateAsync(language);
        }

        public async Task<bool> DeleteLanguageAsync(int id)
        {
            var oldLanguage = await _languageRepository.GetAsync(id);
            if (oldLanguage != null) {
                return await _languageRepository.DeleteAsync(oldLanguage);
            }
            return false;
        }

        public async Task<IEnumerable<Language>> GetLanguageAsync()
        {
            return await _languageRepository.GetAllAsync();
        }

        public async Task<Language> GetLanguageById(int id)
        {
            return await _languageRepository.GetAsync(id);
        }

        public async Task<Language> UpdateLanguageAsync(int id, Language language)
        {
            var oldLanguage = await _languageRepository.GetAsync(id);
            if (oldLanguage != null) {
                oldLanguage.LanguageName = language.LanguageName;
                oldLanguage.UpdatedAt = DateTime.Now;

                return await _languageRepository.UpdateAsync(oldLanguage);
            }
            return oldLanguage;
        }
    }
}
