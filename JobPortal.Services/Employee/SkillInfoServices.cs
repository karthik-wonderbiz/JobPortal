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
using static JobPortal.DTO.Employee.SkillInfoDto;

namespace JobPortal.Services.Employee
{
    public class SkillInfoServices : ISkillInfoServices
    {
        private readonly ISkillInfoRepository _skillInfoRepository;

        public SkillInfoServices(ISkillInfoRepository skillInfoRepository)
        {
            _skillInfoRepository = skillInfoRepository;
        }

        public async Task<GetSkillInfoDto> CreateSkillInfoAsync(CreateSkillInfoDto createSkillInfoDto)
        {
            try
            {
                var skillInfo = await _skillInfoRepository.CreateAsync(new SkillInfo()
                {
                    UserId = createSkillInfoDto.UserId,
                    SkillId = createSkillInfoDto.SkillId,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                });

                var createdSkillInfo = new GetSkillInfoDto(
                    skillInfo.Id,
                    skillInfo.User.Email,
                    skillInfo.Skill.SkillName,
                    skillInfo.SkillExperience
                );

                return createdSkillInfo;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GetSkillInfoDto> GetSkillInfoAsync(long id)
        {
            try
            {
                var skillInfo = await _skillInfoRepository.GetAsync(id);
                if (skillInfo == null)
                {
                    throw new Exception($"Skill Info not found for id : {id}");
                }

                var skillInfoDto = new GetSkillInfoDto(
                    skillInfo.Id,
                    skillInfo.User.Email,
                    skillInfo.Skill.SkillName,
                    skillInfo.SkillExperience
                );

                return skillInfoDto;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<GetSkillInfoDto>> GetSkillInfoByUserId(long userId)
        {
            try
            {
                var skillInfos = await _skillInfoRepository.GetByUserId(userId);

                var skillInfoDtos = skillInfos.Select(skillInfo => new GetSkillInfoDto(
                    skillInfo.Id,
                    skillInfo.User.Email,
                    skillInfo.Skill.SkillName,
                    skillInfo.SkillExperience
                ));

                return skillInfoDtos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<GetSkillInfoDto>> GetSkillInfosAsync()
        {
            try
            {
                var skillInfos = await _skillInfoRepository.GetAllAsync();

                var skillInfoDtos = skillInfos.Select(skillInfo => new GetSkillInfoDto(
                    skillInfo.Id,
                    skillInfo.User.Email,
                    skillInfo.Skill.SkillName,
                    skillInfo.SkillExperience
                ));

                return skillInfoDtos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GetSkillInfoDto> UpdateSkillInfoAsync(long id, UpdateSkillInfoDto updateSkillInfoDto)
        {
            try
            {
                var oldSkillInfo = await _skillInfoRepository.GetAsync(id);
                if (oldSkillInfo == null)
                {
                    throw new Exception($"Skill not found for id : {id}");
                }

                oldSkillInfo.SkillId = updateSkillInfoDto.SkillId;
                oldSkillInfo.UpdatedAt = DateTime.Now;

                await _skillInfoRepository.UpdateAsync(oldSkillInfo);

                var updatedSkillDto = new GetSkillInfoDto(
                    oldSkillInfo.Id,
                    oldSkillInfo.User.Email,
                    oldSkillInfo.Skill.SkillName,
                    oldSkillInfo.SkillExperience
                );

                return updatedSkillDto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteSkillInfoAsync(long id)
        {
            try
            {
                var skillInfo = await _skillInfoRepository.GetAsync(id);
                if (skillInfo == null)
                {
                    throw new Exception($"Skill Info not found for id : {id}");
                }

                var deleted = await _skillInfoRepository.DeleteAsync(skillInfo);
                return deleted;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
