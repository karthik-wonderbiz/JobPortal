using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.DTO.Employee
{
    public class SkillInfoDto
    {
        public record CreateSkillInfoDto(
            [Required] long UserId,
            [Required] long SkillId,
            [Required] int SkillExperience
        );
        public record GetSkillInfoDto(
            long Id,
            string Email,
            string SkillName,
            int SkillExperince
        );
        public record UpdateSkillInfoDto(
            long Id,
            long UserId,
            long SkillId,
            int SkillExperience
        );
    }
}
