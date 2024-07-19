using JobPortal.Data;
using JobPortal.DTO.Company;
using JobPortal.IRepository.Company;
using JobPortal.IServices.Company;
using JobPortal.Model;
using JobPortal.Model.Company;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Services.Company
{
    public class RecruiterServices : IRecruiterServices
    {
        private readonly IRecruiterRepository _recruiterRepository;
        private readonly ICompanyInfoRepository _companyInfoRepository;

        public RecruiterServices(IRecruiterRepository recruiterRepository, ICompanyInfoRepository companyInfoRepository)
        {
            _recruiterRepository = recruiterRepository;
            _companyInfoRepository = companyInfoRepository;
        }

        public async Task<GetRecruiterDto> CreateRecruiterAsync(CreateRecruiterDto recruiterDto)
        {
            try
            {
                var recruiter = await _recruiterRepository.CreateAsync(new Recruiter()
                {
                    CompanyId = recruiterDto.CompanyId,
                    RecruiterName = recruiterDto.RecruiterName,
                    RecruiterEmail = recruiterDto.RecruiterEmail,
                    RecruiterPhone = recruiterDto.RecruiterPhone,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                });

                var res = new GetRecruiterDto(recruiter.Id, recruiter.RecruiterName, recruiter.RecruiterPhone, recruiter.RecruiterEmail);
                return res;
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException?.Message.Contains("Cannot insert duplicate key row") == true ||
                    ex.InnerException?.Message.Contains("UNIQUE constraint failed") == true)
                {
                    throw new Exception("This Recruiter already exists.");
                }
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteRecruiterAsync(long id)
        {
            try
            {
                var oldRecruiter = await _recruiterRepository.GetAsync(id);
                if (oldRecruiter == null)
                {
                    throw new Exception($"No Recruiter found for id : {id}");
                }

                var res = await _recruiterRepository.DeleteAsync(oldRecruiter);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<GetRecruiterDto>> GetAllRecruiterAsync()
        {
            try
            {
                var recruiters = await _recruiterRepository.GetAllAsync();

                var recruiterDto = recruiters.Select(recruiter => new GetRecruiterDto(
                    recruiter.Id,
                    recruiter.RecruiterName,
                    recruiter.RecruiterPhone,
                    recruiter.RecruiterEmail
                ));

                return recruiterDto.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GetRecruiterDto> GetRecruiterByIdAsync(long id)
        {
            try
            {
                var recruiter = await _recruiterRepository.GetAsync(id);
                if (recruiter == null)
                {
                    throw new Exception($"No Recruiter found for id : {id}");
                }

                var res = new GetRecruiterDto(recruiter.Id, recruiter.RecruiterName, recruiter.RecruiterPhone, recruiter.RecruiterEmail);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GetRecruiterDto> UpdateRecruiterAsync(long id, UpdateRecruiterDto recruiterDto)
        {
            try
            {
                var oldRecruiter = await _recruiterRepository.GetAsync(id);
                if (oldRecruiter == null)
                {
                    throw new Exception($"No Recruiter found for id : {id}");
                }

                oldRecruiter.RecruiterName = recruiterDto.RecruiterName;
                oldRecruiter.RecruiterPhone = recruiterDto.RecruiterPhone;
                oldRecruiter.RecruiterEmail = recruiterDto.RecruiterEmail;
                oldRecruiter.UpdatedAt = DateTime.Now;

                await _recruiterRepository.UpdateAsync(oldRecruiter);

                var res = new GetRecruiterDto(oldRecruiter.Id, oldRecruiter.RecruiterName, oldRecruiter.RecruiterPhone, oldRecruiter.RecruiterEmail);
                return res;
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException?.Message.Contains("Cannot insert duplicate key row") == true ||
                    ex.InnerException?.Message.Contains("UNIQUE constraint failed") == true)
                {
                    throw new Exception("This Recruiter already exists.");
                }
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
