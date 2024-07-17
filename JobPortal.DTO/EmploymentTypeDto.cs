using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.DTO
{
    public class EmploymentTypeDto
    {
    }

    public record CreateEmploymentTypeDto(
        [Required(ErrorMessage = "EmploymentTypeName is required")] string EmploymentTypeName,
        DateTime CreatedAt,
        DateTime UpdatedAt,
        string EmploymentTypeCode = ""
        );

    public record UpdateEmploymentTypeDto(
        [Required(ErrorMessage = "EmploymentTypeName is required")] string EmploymentTypeName,
        bool IsActive,
        DateTime UpdatedAt,
        string EmploymentTypeCode = ""
        );

    public record GetEmploymentTypeDto(
        long Id,
        string EmploymentTypeName,
        string EmploymentTypeCode,
        bool IsActive
        );
}
