using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Data
{
    public class ShiftDto
    {
    }

    public record CreateShiftDto(
        [Required(ErrorMessage = "ShiftName is required")] string ShiftName, 
        DateTime CreatedAt, 
        DateTime UpdatedAt, 
        string ShiftCode = " "
        );
    public record UpdateShiftDto(
        [Required(ErrorMessage = "Id is required")] long Id, 
        [Required(ErrorMessage = "ShiftName is required")] string ShiftName, 
        bool IsActive, 
        DateTime UpdatedAt, 
        string ShiftCode = " "
        );
    public record GetShiftDto(long Id, string ShiftName, string ShiftCode, bool IsActive);
}
