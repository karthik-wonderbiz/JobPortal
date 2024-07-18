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
        DateTime CreatedAt,
        DateTime UpdatedAt,
        string SkillCode = ""
        );

    public record UpdateSkillDto(
        [Required(ErrorMessage = "Skill Name is required")] string SkillName,
        bool IsActive,
        DateTime UpdatedAt,
        string SkillCode = ""
        );

    public record GetSkillDto(
        long Id,
        string SkillName,
        string SkillCode,
        bool IsActive
        );
}
