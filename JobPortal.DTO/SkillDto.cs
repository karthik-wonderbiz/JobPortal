using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.DTO
{
    public class SkillDto
    {
    }

    public record CreateSkillDto(
        [Required(ErrorMessage = "Skill Name is required")] string SkillName,
        [Required(ErrorMessage = "Skill Experience is required")] int SkillExperience,
        DateTime CreatedAt,
        DateTime UpdatedAt,
        string SkillCode = ""
        );

    public record UpdateSkillDto(
        [Required(ErrorMessage = "Skill Name is required")] string SkillName,
        [Required(ErrorMessage = "Skill Experience is required")] int SkillExperience,
        bool IsActive,
        DateTime UpdatedAt,
        string SkillCode = ""
        );

    public record GetSkillDto(
        long Id,
        string SkillName,
        int SkillExperience,
        string SkillCode,
        bool IsActive
        );
}
