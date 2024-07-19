using JobPortal.DTO;
using JobPortal.DTO.Employee;
using JobPortal.IRepository;
using JobPortal.IRepository.Employee;
using JobPortal.IServices.Employee;
using JobPortal.Model;
using JobPortal.Model.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JobPortal.DTO.Employee.CertificationInfoDto;

namespace JobPortal.Services.Employee
{
    public class CertificationInfoServices : ICertificationInfoServices
    {
        private readonly ICertificationInfoRepository _certificationInfoRepository;
        private readonly IUserRepository _userRepository;

        public CertificationInfoServices(
            ICertificationInfoRepository certificationInfoRepository,
            IUserRepository userRepository
            )
        {
            _certificationInfoRepository = certificationInfoRepository;
            _userRepository = userRepository;
        }

        public async Task<GetCertificationInfoDto> CreateCertificationInfoAsync(CreateCertificationInfoDto createCertificationInfoDto)
        {
            try
            {
                var certificationInfo = await _certificationInfoRepository.CreateAsync(new CertificationInfo()
                {
                    UserId = createCertificationInfoDto.UserId,
                    CertficateName = createCertificationInfoDto.CertficateName,
                    OrganisationName = createCertificationInfoDto.OrganisationName,
                    IssueDate = createCertificationInfoDto.IssueDate,
                    ExpiryDate = createCertificationInfoDto.ExpiryDate,
                    SkillAcquired = createCertificationInfoDto.SkillAcquired,
                    CertificateURL = createCertificationInfoDto.CertificateURL,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                });

                var user = await _userRepository.GetAsync(certificationInfo.UserId);

                if (user != null)
                {

                    var createdCertificationInfo = new GetCertificationInfoDto(
                        certificationInfo.Id,
                        user.Email,
                        certificationInfo.CertficateName,
                        certificationInfo.OrganisationName,
                        certificationInfo.IssueDate,
                        certificationInfo.ExpiryDate,
                        certificationInfo.SkillAcquired,
                        certificationInfo.CertificateURL
                    );

                    return createdCertificationInfo;
                }
                else
                {
                    throw new Exception("Invalid User");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GetCertificationInfoDto> GetCertificationInfoAsync(long id)
        {
            try
            {
                var certificationInfo = await _certificationInfoRepository.GetAsync(id);

                if (certificationInfo == null)
                {
                    throw new Exception($"Location Info not found for id : {id}");
                }

                var certificationInfoDto = new GetCertificationInfoDto(
                    certificationInfo.Id,
                    certificationInfo.User.Email,
                    certificationInfo.CertficateName,
                    certificationInfo.OrganisationName,
                    certificationInfo.IssueDate,
                    certificationInfo.ExpiryDate,
                    certificationInfo.SkillAcquired,
                    certificationInfo.CertificateURL
                );

                return certificationInfoDto;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<GetCertificationInfoDto>> GetCertificationInfoByUserId(long userId)
        {
            try
            {
                var certificationInfos = await _certificationInfoRepository.GetByUserId(userId);

                var certificationInfoDtos = certificationInfos.Select(certificationInfo => new GetCertificationInfoDto(
                    certificationInfo.Id,
                    certificationInfo.User.Email,
                    certificationInfo.CertficateName,
                    certificationInfo.OrganisationName,
                    certificationInfo.IssueDate,
                    certificationInfo.ExpiryDate,
                    certificationInfo.SkillAcquired,
                    certificationInfo.CertificateURL
                ));

                return certificationInfoDtos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<GetCertificationInfoDto>> GetCertificationInfosAsync()
        {
            try
            {
                var certificationInfos = await _certificationInfoRepository.GetAllAsync();

                var certificationInfoDtos = certificationInfos.Select(certificationInfo => new GetCertificationInfoDto(
                    certificationInfo.Id,
                    certificationInfo.User.Email,
                    certificationInfo.CertficateName,
                    certificationInfo.OrganisationName,
                    certificationInfo.IssueDate,
                    certificationInfo.ExpiryDate,
                    certificationInfo.SkillAcquired,
                    certificationInfo.CertificateURL
                ));

                return certificationInfoDtos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GetCertificationInfoDto> UpdateCertificationInfoAsync(long id, UpdateCertificationInfoDto updateCertificationInfoDto)
        {
            try
            {
                var oldCertificationInfo = await _certificationInfoRepository.GetAsync(id);
                if (oldCertificationInfo == null)
                {
                    throw new Exception($"Location not found for id : {id}");
                }

                oldCertificationInfo.UserId = updateCertificationInfoDto.UserId;
                oldCertificationInfo.CertficateName = updateCertificationInfoDto.CertficateName;
                oldCertificationInfo.OrganisationName = updateCertificationInfoDto.OrganisationName;
                oldCertificationInfo.IssueDate = updateCertificationInfoDto.IssueDate;
                oldCertificationInfo.ExpiryDate = updateCertificationInfoDto.ExpiryDate;
                oldCertificationInfo.SkillAcquired = updateCertificationInfoDto.SkillAcquired;
                oldCertificationInfo.CertificateURL = updateCertificationInfoDto.CertificateURL;
                oldCertificationInfo.UpdatedAt = DateTime.Now;

                await _certificationInfoRepository.UpdateAsync(oldCertificationInfo);

                var user = await _userRepository.GetAsync(oldCertificationInfo.UserId);

                if (user != null)
                {

                    var updatedCertificationInfo = new GetCertificationInfoDto(
                        oldCertificationInfo.Id,
                        user.Email,
                        oldCertificationInfo.CertficateName,
                        oldCertificationInfo.OrganisationName,
                        oldCertificationInfo.IssueDate,
                        oldCertificationInfo.ExpiryDate,
                        oldCertificationInfo.SkillAcquired,
                        oldCertificationInfo.CertificateURL
                    );

                    return updatedCertificationInfo;
                }
                else
                {
                    throw new Exception("Invalid User");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteCertificationInfoAsync(long id)
        {
            try
            {
                var certificationInfo = await _certificationInfoRepository.GetAsync(id);
                if (certificationInfo == null)
                {
                    throw new Exception($"Location Info not found for id : {id}");
                }

                var deleted = await _certificationInfoRepository.DeleteAsync(certificationInfo);
                return deleted;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
