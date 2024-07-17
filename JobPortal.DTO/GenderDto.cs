using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.DTO
{
    public class GenderDto
    {
    }

    public record CreateGenderDto(
        [Required(ErrorMessage = "GenderName is required")] string GenderName,
        DateTime CreatedAt,
        DateTime UpdatedAt,
        string GenderCode = ""
        );

    public record UpdateGenderDto(
        [Required(ErrorMessage = "GenderName is required")] string GenderName, 
        bool IsActive, 
        DateTime UpdatedAt, 
        string GenderCode = ""
        );

    public record GetGenderDto(
        long Id, 
        string GenderName, 
        string GenderCode, 
        bool IsActive
        );
}
