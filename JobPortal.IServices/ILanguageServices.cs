using JobPortal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.IServices
{
    public interface ILanguageServices
    {
        public Task<IEnumerable<Language>> GetLanguageAsync();
        public Task<Language> GetLanguageById(long id);
        public Task<Language> CreateLanguageAsync(Language language);
        public Task<Language> UpdateLanguageAsync(long id, Language language);
        public Task<bool> DeleteLanguageAsync(long id);
    }
}
