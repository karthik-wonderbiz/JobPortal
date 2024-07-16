using JobPortal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JobPortal.DTO.LanguageDto;

namespace JobPortal.IServices
{
    public interface ILanguageServices
    {
        public Task<IEnumerable<GetLanguageDto>> GetLanguageAsync();
        public Task<GetLanguageDto> GetLanguageById(long id);
        public Task<GetLanguageDto> CreateLanguageAsync(CreateLanguageDto createLanguageDto);
        public Task<GetLanguageDto> UpdateLanguageAsync(long id, UpdateLanguageDto updateLanguageDto);
        public Task<bool> DeleteLanguageAsync(long id);
    }
}
