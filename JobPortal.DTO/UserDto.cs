using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Data
{
    public class UserDto
    {
    }

    public record CreateUserDto([Required(ErrorMessage = "Email is required")] string Email, [Required(ErrorMessage = "Password is required")] string Password, [Required(ErrorMessage = "Contact is required")] long Contact, DateTime CreatedAt, DateTime UpdatedAt);
    public record UpdateUserDto([Required(ErrorMessage = "Id is required")] long Id, [Required(ErrorMessage = "Email is required")] string Email, [Required(ErrorMessage = "Password is required")] string Password, [Required(ErrorMessage = "Contact is required")] long Contact, bool IsActive, DateTime CreatedAt, DateTime UpdatedAt);
    public record GetUserDto(long Id, string Email, string Password, long Contact, bool IsActive);
}
