using JobPortal.Data;
using JobPortal.DTO.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.IServices.Company
{
    public interface ICompanyInfoServices
    {
        public Task<GetCompanyInfoDto> GetCompanyInfoByIdAsync(long id);
        public Task<IEnumerable<GetCompanyInfoDto>> GetAllCompaniesAsync();
        public Task<GetCompanyInfoDto> CreateCompanyInfoAsync(CreateCompanyInfoDto companyInfoDto);
        public Task<GetCompanyInfoDto> UpdateCompanyInfoAsync(long id, UpdateCompanyInfoDto companyInfoDto);
        public Task<bool> DeleteCompanyInfoAsync(long id);
        public Task<IEnumerable<GetCompanyInfoDto>> GetCompanyInfoByUserIdAsync(long userId);
    }
}
