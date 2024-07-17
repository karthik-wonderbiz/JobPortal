using JobPortal.DTO;
using JobPortal.IRepository;
using JobPortal.IServices;
using JobPortal.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
                    SkillExperience = skillDto.SkillExperience,
                    SkillCode = skillDto.SkillName.ToUpper().Substring(0, 1),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                });

                var createdSkill = new GetSkillDto(
                    skill.Id,
                    skill.SkillName,
                    skill.SkillExperience,
                    skill.SkillCode,
                    skill.IsActive
                );

                return createdSkill;
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException?.Message.Contains("Cannot insert duplicate key row") == true ||
                    ex.InnerException?.Message.Contains("UNIQUE constraint failed") == true)
                {
                    throw new Exception("This skill already exists.");
                }
                throw;
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
                    throw new Exception($"Skill not found for id : {id}");
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

                var skillDtos = skills.Select(skill => new GetSkillDto(
                    skill.Id,
                    skill.SkillName,
                    skill.SkillExperience,
                    skill.SkillCode,
                    skill.IsActive
                ));

                return skillDtos.ToList();
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
                    throw new Exception($"Skill not found for id : {id}");
                }

                oldSkill.SkillName = skillDto.SkillName;
                oldSkill.SkillExperience = skillDto.SkillExperience;
                oldSkill.SkillCode = !string.IsNullOrEmpty(skillDto.SkillCode) ? skillDto.SkillCode : skillDto.SkillName.ToUpper().Substring(0, 1);
                oldSkill.UpdatedAt = DateTime.Now;

                await _skillRepository.UpdateAsync(oldSkill);

                var updatedSkill = new GetSkillDto(
                    oldSkill.Id,
                    oldSkill.SkillName,
                    oldSkill.SkillExperience,
                    oldSkill.SkillCode,
                    oldSkill.IsActive
                );

                return updatedSkill;
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException?.Message.Contains("Cannot insert duplicate key row") == true ||
                    ex.InnerException?.Message.Contains("UNIQUE constraint failed") == true)
                {
                    throw new Exception("This skill already exists.");
                }
                throw;
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
                    throw new Exception($"Skill not found for id : {id}");
                }

                var deleted = await _skillRepository.DeleteAsync(skill);
                return deleted;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
