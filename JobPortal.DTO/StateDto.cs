using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Data
{
    public class StateDto
    {
    }

    public record CreateStateDto(
        [Required(ErrorMessage = "StateName is required")] string StateName, 
        DateTime CreatedAt, 
        DateTime UpdatedAt, 
        string StateCode = " "
        );
    public record UpdateStateDto(
        [Required(ErrorMessage = "Id is required")] long Id, 
        [Required(ErrorMessage = "StateName is required")] string StateName, 
        bool IsActive, 
        DateTime UpdatedAt, 
        string StateCode = " "
        );
    public record GetStateDto(long Id, string StateName, string StateCode, bool IsActive);
}
