using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.DTO
{
    public class QualificationDto
    {
    }

    public record CreateQualificationDto(
        [Required(ErrorMessage = "Qualification Name is required")] string QualificationName,
        DateTime CreatedAt,
        DateTime UpdatedAt,
        string QualificationCode = ""
        );

    public record UpdateQualificationDto(
        [Required(ErrorMessage = "Qualification Name is required")] string QualificationName,
        bool IsActive,
        DateTime UpdatedAt,
        string QualificationCode = ""
        );

    public record GetQualificationDto(
        long Id,
        string QualificationName,
        string QualificationCode,
        bool IsActive
        );
}
