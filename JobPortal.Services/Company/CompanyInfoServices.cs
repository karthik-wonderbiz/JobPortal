using JobPortal.DTO;
using JobPortal.DTO.Company;
using JobPortal.IRepository;
using JobPortal.IRepository.Company;
using JobPortal.IServices;
using JobPortal.IServices.Company;
using JobPortal.Model;
using JobPortal.Model.Company;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static JobPortal.DTO.Company.CompanyInfoDto;

namespace JobPortal.Services.Company
{
    public class CompanyInfoServices : ICompanyInfoServices
    {
        private readonly ICompanyInfoRepository _companyInfoRepository;
        private readonly IUserRepository _userRepository;

        public CompanyInfoServices(ICompanyInfoRepository companyInfoRepository, IUserRepository userRepository)
        {
            _companyInfoRepository = companyInfoRepository;
            _userRepository = userRepository;
        }

        public async Task<GetCompanyInfoDto> CreateCompanyInfoAsync(CreateCompanyInfoDto companyInfoDto)
        {
            try
            {
                var companyInfo = await _companyInfoRepository.CreateAsync(new CompanyInfo()
                {
                    UserId = companyInfoDto.UserId,
                    CompanyDescription = companyInfoDto.CompanyDescription,
                    CompanyName = companyInfoDto.CompanyName,
                    CompanyEmail = companyInfoDto.CompanyEmail,
                    CompanyPhone = companyInfoDto.CompanyPhone,
                    CompanyWebsite = companyInfoDto.CompanyWebsite,
                    CompanyLogo = companyInfoDto.CompanyLogo,
                    CompanyDomain = companyInfoDto.CompanyDomain,
                    WorkingDays = companyInfoDto.WorkingDays,
                    OpenHours = companyInfoDto.OpenHours,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                });

                var createdCompanyInfo = new GetCompanyInfoDto(companyInfo.Id, companyInfo.CompanyDescription, companyInfo.CompanyName, companyInfo.CompanyPhone, companyInfo.CompanyEmail, companyInfo.CompanyLogo, companyInfo.CompanyWebsite, companyInfo.CompanyDomain, companyInfo.WorkingDays, companyInfo.OpenHours);
                return createdCompanyInfo;
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException?.Message.Contains("Cannot insert duplicate key row") == true ||
                    ex.InnerException?.Message.Contains("UNIQUE constraint failed") == true)
                {
                    throw new Exception("This company already exists.");
                }
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<GetCompanyInfoDto>> GetAllCompaniesAsync()
        {
            try
            {
                var companies = await _companyInfoRepository.GetAllAsync();

                var companyInfoDtos = companies.Select(companyInfo => new GetCompanyInfoDto(
                    companyInfo.Id, companyInfo.CompanyDescription, companyInfo.CompanyName, companyInfo.CompanyPhone, companyInfo.CompanyEmail, companyInfo.CompanyLogo, companyInfo.CompanyWebsite, companyInfo.CompanyDomain, companyInfo.WorkingDays, companyInfo.OpenHours
                ));

                return companyInfoDtos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GetCompanyInfoDto> GetCompanyInfoByIdAsync(long id)
        {
            try
            {
                var companyInfo = await _companyInfoRepository.GetAsync(id);
                if (companyInfo == null)
                {
                    throw new Exception($"Company not found for id : {id}");
                }

                var companyInfoDto = new GetCompanyInfoDto(companyInfo.Id, companyInfo.CompanyDescription, companyInfo.CompanyName, companyInfo.CompanyPhone, companyInfo.CompanyEmail, companyInfo.CompanyLogo, companyInfo.CompanyWebsite, companyInfo.CompanyDomain, companyInfo.WorkingDays, companyInfo.OpenHours);
                return companyInfoDto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<GetCompanyInfoDto>> GetCompanyInfoByUserIdAsync(long userId)
        {
            try
            {
                var companies = await _companyInfoRepository.GetCompanyInfoByUserId(userId);

                var companyInfoDto = companies.Select(companyInfo => new GetCompanyInfoDto(
                    companyInfo.Id, companyInfo.CompanyDescription, companyInfo.CompanyName, companyInfo.CompanyPhone, companyInfo.CompanyEmail, companyInfo.CompanyLogo, companyInfo.CompanyWebsite, companyInfo.CompanyDomain, companyInfo.WorkingDays, companyInfo.OpenHours
                ));

                return companyInfoDto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GetCompanyInfoDto> UpdateCompanyInfoAsync(long id, UpdateCompanyInfoDto companyInfoDto)
        {
            try
            {
                var oldCompanyInfo = await _companyInfoRepository.GetAsync(id);
                if (oldCompanyInfo == null)
                {
                    throw new Exception($"Company not found for id : {id}");
                }

                oldCompanyInfo.UserId = companyInfoDto.UserId;
                oldCompanyInfo.CompanyDescription = companyInfoDto.CompanyDescription;
                oldCompanyInfo.CompanyName = companyInfoDto.CompanyName;
                oldCompanyInfo.CompanyPhone = companyInfoDto.CompanyPhone;
                oldCompanyInfo.CompanyEmail = companyInfoDto.CompanyEmail;
                oldCompanyInfo.CompanyLogo = companyInfoDto.CompanyLogo;
                oldCompanyInfo.CompanyWebsite = companyInfoDto.CompanyWebsite;
                oldCompanyInfo.CompanyDomain = companyInfoDto.CompanyDomain;
                oldCompanyInfo.WorkingDays = companyInfoDto.WorkingDays;
                oldCompanyInfo.OpenHours = companyInfoDto.OpenHours;
                oldCompanyInfo.UpdatedAt = DateTime.Now;

                await _companyInfoRepository.UpdateAsync(oldCompanyInfo);

                var updatedCompanyInfo = new GetCompanyInfoDto(oldCompanyInfo.Id, oldCompanyInfo.CompanyDescription, oldCompanyInfo.CompanyName, oldCompanyInfo.CompanyPhone, oldCompanyInfo.CompanyEmail, oldCompanyInfo.CompanyLogo, oldCompanyInfo.CompanyWebsite, oldCompanyInfo.CompanyDomain, oldCompanyInfo.WorkingDays, oldCompanyInfo.OpenHours);
                return updatedCompanyInfo;
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException?.Message.Contains("Cannot insert duplicate key row") == true ||
                    ex.InnerException?.Message.Contains("UNIQUE constraint failed") == true)
                {
                    throw new Exception("This company already exists.");
                }
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteCompanyInfoAsync(long id)
        {
            try
            {
                var companyInfo = await _companyInfoRepository.GetAsync(id);
                if (companyInfo == null)
                {
                    throw new Exception($"Company not found for id : {id}");
                }

                var deleted = await _companyInfoRepository.DeleteAsync(companyInfo);
                return deleted;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
