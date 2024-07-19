using JobPortal.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JobPortal.DTO.Company.CompanyInfoDto;

namespace JobPortal.IServices.Company
{
    public interface ICompanyInfoServices
    {
        Task<GetCompanyInfoDto> GetCompanyInfoByIdAsync(long id);
        Task<IEnumerable<GetCompanyInfoDto>> GetAllCompaniesAsync();
        Task<GetCompanyInfoDto> CreateCompanyInfoAsync(CreateCompanyInfoDto companyInfoDto);
        Task<GetCompanyInfoDto> UpdateCompanyInfoAsync(long id, UpdateCompanyInfoDto companyInfoDto);
        Task<bool> DeleteCompanyInfoAsync(long id);
        Task<IEnumerable<GetCompanyInfoDto>> GetCompanyInfoByUserIdAsync(long userId);
    }
}
