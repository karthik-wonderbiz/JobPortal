using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Data
{
    public class CountryDto
    {
    }

    public record CreateCountryDto([Required(ErrorMessage = "CountryName is required")] string CountryName, DateTime CreatedAt, DateTime UpdatedAt, string CountryCode = " ");
    public record UpdateCountryDto([Required(ErrorMessage = "Id is required")] int Id, [Required(ErrorMessage = "CountryName is required")] string CountryName, bool IsActive, DateTime UpdatedAt ,string CountryCode = " ");
    public record GetCountryDto(long Id, string CountryName, string CountryCode, bool IsActive);
}
