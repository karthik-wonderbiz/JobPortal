using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.DTO.Company
{
    public class CompanyInfoDto
    {
    }
    public record 
        CreateCompanyInfoDto
        (
        [Required(ErrorMessage = "User Id is required!")] long UserId,
        [Required(ErrorMessage = "Company Description is required!")] string CompanyDescription,
        [Required(ErrorMessage = "Company Name is required!")] string CompanyName,
        [Required(ErrorMessage = "Company Phone Number is required!")] long CompanyPhone,
        [Required(ErrorMessage = "Company Email is required!")] string CompanyEmail,
        DateTime CreatedAt,
        DateTime UpdatedAt,
        string CompanyLogo = " ",
        string CompanyWebsite = " ",
        string CompanyDomain = " ",
        string WorkingDays = " ",
        string OpenHours = " "
        );

    public record 
        UpdateCompanyInfoDto
        (
        [Required(ErrorMessage = "Id is required")] long Id,
        [Required(ErrorMessage = "User Id is required!")] long UserId,
        [Required(ErrorMessage = "Company Description is required!")] string CompanyDescription,
        [Required(ErrorMessage = "Company Name is required!")] string CompanyName,
        [Required(ErrorMessage = "Company Phone Number is required!")] long CompanyPhone,
        [Required(ErrorMessage = "Company Email is required!")] string CompanyEmail,
        DateTime UpdatedAt,
        string CompanyLogo = " ",
        string CompanyWebsite = " ",
        string CompanyDomain = " ",
        string WorkingDays = " ",
        string OpenHours = " "
        );

    public record 
        GetCompanyInfoDto
        (
        long Id,
        long UserId,
        string CompanyDescription,
        string CompanyName,
        long CompanyPhone,
        string CompanyEmail,
        string CompanyLogo,
        string CompanyWebsite,
        string CompanyDomain,
        string WorkingDays,
        string OpenHours
        );
}
