using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.DTO.Company
{
    public class RecruiterDto
    {
    }
    public record CreateRecruiterDto
        (
        [Required(ErrorMessage = "Company Id is required!")] long CompanyId,
        [Required(ErrorMessage = "Recruiter Name is required!")] string RecruiterName,
        [Required(ErrorMessage = "Recruiter Phone Number is required!")] long RecruiterPhone,
        [Required(ErrorMessage = "Recruiter Email is required!")] string RecruiterEmail,
        DateTime CreatedAt,
        DateTime UpdatedAt
        );

    public record UpdateRecruiterDto
        (
        [Required(ErrorMessage = "Id is required")] long Id,
        [Required(ErrorMessage = "Company Id is required!")] long CompanyId,
        [Required(ErrorMessage = "Recruiter Name is required!")] string RecruiterName,
        [Required(ErrorMessage = "Recruiter Phone Number is required!")] long RecruiterPhone,
        [Required(ErrorMessage = "Recruiter Email is required!")] string RecruiterEmail,
        DateTime UpdatedAt
        );

    public record GetRecruiterDto
        (
            long Id,
            string RecruiterName,
            long RecruiterPhone,
            string RecruiterEmail
        );
}
