using JobPortal.DTO.Company;
using JobPortal.IRepository;
using JobPortal.IRepository.Company;
using JobPortal.IRepository.Employee;
using JobPortal.IServices.Company;
using JobPortal.Model.Company;
using JobPortal.Model.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JobPortal.DTO.Company.ApplyInfoDto;

namespace JobPortal.Services.Company
{
    public class ApplyInfoServices : IApplyInfoServices
    {
        private readonly IApplyInfoRepository _applyInfoRepository;
        private readonly IJobPostRepository _jobPostRepository;
        private readonly IUserRepository _userRepository;

        public ApplyInfoServices(IApplyInfoRepository applyInfoRepository, IUserRepository userRepository, IJobPostRepository jobPostRepository)
        {
            _applyInfoRepository = applyInfoRepository;
            _userRepository = userRepository;
            _jobPostRepository = jobPostRepository;
        }
        public async Task<GetApplyInfoDto> CreateApplyInfoAsync(CreateApplyInfoDto createApplyInfoDto)
        {
            try
            {
                var applyInfo = await _applyInfoRepository.CreateAsync(new ApplyInfo()
                {
                    UserId = createApplyInfoDto.UserId,
                    JobPostId = createApplyInfoDto.JobPostId,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,

                });
                var user = await _userRepository.GetAsync(applyInfo.UserId);
                var jobPost = await _jobPostRepository.GetAsync(applyInfo.JobPostId);
                if (user != null &&
                    jobPost != null)
                {

                    var res = new GetApplyInfoDto(applyInfo.Id, user.Email, jobPost.JobDescription);

                    return res;
                }
                else
                {
                    throw new Exception("Invalid user id");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteApplyInfoAsync(long id)
        {
            try
            {
                var oldApplyInfo = await _applyInfoRepository.GetAsync(id);
                if (oldApplyInfo == null)
                {
                    throw new Exception($"No Job Post found for id : {id}");
                }

                var res = await _applyInfoRepository.DeleteAsync(oldApplyInfo);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<GetApplyInfoDto>> GetApplyInfoAsync()
        {
            try
            {
                var applyInfos = await _applyInfoRepository.GetAllAsync();
                var applyInfoDto = applyInfos.Select(applyInfo => new GetApplyInfoDto(applyInfo.Id, applyInfo.JobPost.JobDescription, applyInfo.User.Email));
                return applyInfoDto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GetApplyInfoDto> GetApplyInfoById(long id)
        {
            try
            {
                var applyInfo = await _applyInfoRepository.GetAsync(id);
                if (applyInfo == null)
                {
                    throw new Exception($"No JobPost found for id : {id}");
                }

                var res = new GetApplyInfoDto(applyInfo.Id, applyInfo.User.Email, applyInfo.JobPost.JobDescription);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<GetApplyInfoDto>> GetApplyInfoByUserId(long userId)
        {
            try
            {
                var applyInfo = await _applyInfoRepository.GetApplyInfoByUserId(userId);

                var applyInfoDtos = applyInfo.Select(applyInfo => new GetApplyInfoDto(
                    applyInfo.Id,
                    applyInfo.User.Email,
                    applyInfo.JobPost.JobDescription
                ));

                return applyInfoDtos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GetApplyInfoDto> UpdateApplyInfoAsync(long id, UpdateApplyInfoDto updateApplyInfoDto)
        {
            try
            {
                var oldApplyInfo = await _applyInfoRepository.GetAsync(id);
                if (oldApplyInfo == null)
                {
                    throw new Exception($"No JobPost found for id : {id}");
                }

                oldApplyInfo.UserId = updateApplyInfoDto.UserId;
                oldApplyInfo.JobPostId = updateApplyInfoDto.JobPostId;
                oldApplyInfo.UpdatedAt = DateTime.Now;

                await _applyInfoRepository.UpdateAsync(oldApplyInfo);

                var user = await _userRepository.GetAsync(oldApplyInfo.UserId);
                var jobPost = await _jobPostRepository.GetAsync(oldApplyInfo.JobPostId);

                var res = new GetApplyInfoDto(oldApplyInfo.Id, user.Email, jobPost.JobDescription);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
