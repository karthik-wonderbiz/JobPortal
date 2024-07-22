using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JobPortal.DTO.Company.ApplyInfoDto;

namespace JobPortal.IServices.Company
{
    public interface IApplyInfoServices
    {
        public Task<IEnumerable<GetApplyInfoDto>> GetApplyInfoAsync();
        public Task<GetApplyInfoDto> GetApplyInfoById(long id);
        public Task<GetApplyInfoDto> CreateApplyInfoAsync(CreateApplyInfoDto createApplyInfoDto);
        public Task<GetApplyInfoDto> UpdateApplyInfoAsync(long id, UpdateApplyInfoDto updateApplyInfoDto);
        public Task<bool> DeleteApplyInfoAsync(long id);
        public Task<IEnumerable<GetApplyInfoDto>> GetApplyInfoByUserId(long userId);
    }
}
