using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JobPortal.DTO.Employee.LanguageInfoDto;
using static JobPortal.DTO.LanguageDto;

namespace JobPortal.IServices.Employee
{
    public interface ILanguageInfoServices
    {
        public Task<IEnumerable<GetLanguageInfoDto>> GetLanguageInfoAsync();
        public Task<GetLanguageInfoDto> GetLanguageInfoById(long id);
        public Task<GetLanguageInfoDto> CreateLanguageInfoAsync(CreateLanguageInfoDto createLanguageInfoDto);
        public Task<GetLanguageInfoDto> UpdateLanguageInfoAsync(long id, UpdateLanguageInfoDto updateLanguageInfoDto);
        public Task<bool> DeleteLanguageInfoAsync(long id);
        public Task<IEnumerable<GetLanguageInfoDto>> GetLanguageInfoByUserId(long userId);
    }
}
