using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.DTO.Company
{
    public class ContactPersonDto
    {
    }
    public record CreateContactPersonDto
        (
        [Required(ErrorMessage = "Company Id is required!")] long CompanyId,
        [Required(ErrorMessage = "Contact Person Name is required!")] string ContactPersonName,
        [Required(ErrorMessage = "Contact Person Phone Number is required!")] long ContactPersonPhone,
        [Required(ErrorMessage = "Contact Person Email is required!")] string ContactPersonEmail,
        DateTime CreatedAt,
        DateTime UpdatedAt
        );

    public record UpdateContactPersonDto
        (
        [Required(ErrorMessage = "Id is required")] long Id,
        [Required(ErrorMessage = "Company Id is required!")] long CompanyId,
        [Required(ErrorMessage = "Contact Person Name is required!")] string ContactPersonName,
        [Required(ErrorMessage = "Contact Person Phone Number is required!")] long ContactPersonPhone,
        [Required(ErrorMessage = "Contact Person Email is required!")] string ContactPersonEmail,
        DateTime UpdatedAt
        );

    public record GetContactPersonDto
        (
            long Id,
            string ContactPersonName,
            long ContactPersonPhone,
            string ContactPersonEmail
        );
}
