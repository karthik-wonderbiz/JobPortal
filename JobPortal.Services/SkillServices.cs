using JobPortal.DTO;
using JobPortal.IRepository;
using JobPortal.IServices;
using JobPortal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Services
{
    public class SkillServices : ISkillServices
    {
        private readonly ISkillRepository _skillRepository;

        public SkillServices(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public async Task<GetSkillDto> CreateSkillAsync(CreateSkillDto skillDto)
        {
            try
            {
                var skill = await _skillRepository.CreateAsync(new Skill()
                {
                    SkillName = skillDto.SkillName,
                    SkillCode = skillDto.SkillName.ToUpper().Substring(0, 1),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                });

                var res = new GetSkillDto(
                    skill.Id,
                    skill.SkillName,
                    skill.SkillExperience,
                    skill.SkillCode,
                    skill.IsActive
                    );

                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GetSkillDto> GetSkillAsync(long id)
        {
            try
            {
                var skill = await _skillRepository.GetAsync(id);

                if (skill == null)
                {
                    throw new Exception($"No Skill Found with id  {id}");
                }

                var skillDto = new GetSkillDto(
                    skill.Id,
                    skill.SkillName,
                    skill.SkillExperience,
                    skill.SkillCode,
                    skill.IsActive
                    );

                return skillDto;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<GetSkillDto>> GetSkillsAsync()
        {
            try
            {
                var skills = await _skillRepository.GetAllAsync();

                var skillsDto = skills.Select(skill => new GetSkillDto(
                    skill.Id,
                    skill.SkillName,
                    skill.SkillExperience,
                    skill.SkillCode,
                    skill.IsActive
                    ));

                return skillsDto.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GetSkillDto> UpdateSkillAsync(long id, UpdateSkillDto skillDto)
        {
            try
            {
                var oldSkill = await _skillRepository.GetAsync(id);

                if (oldSkill == null)
                {
                    throw new Exception($"No Skill Found for id {id}");
                }

                oldSkill.SkillName = skillDto.SkillName;
                oldSkill.SkillCode = skillDto.SkillCode != string.Empty ? skillDto.SkillCode : skillDto.SkillName.ToUpper().Substring(0, 1);

                oldSkill.UpdatedAt = DateTime.Now;

                var skill = await _skillRepository.UpdateAsync(oldSkill);

                var newSkillDto = new GetSkillDto(
                    skill.Id,
                    skill.SkillName,
                    skill.SkillExperience,
                    skill.SkillCode,
                    skill.IsActive
                    );

                return newSkillDto;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> DeleteSkillAsync(long id)
        {
            try
            {
                var skill = await _skillRepository.GetAsync(id);

                if (skill == null)
                {
                    throw new Exception($"No Skill Found for id {id}");
                }

                bool row = await _skillRepository.DeleteAsync(skill);

                return row;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
