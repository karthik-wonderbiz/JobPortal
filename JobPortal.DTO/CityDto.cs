using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Data
{
    public class CityDto
    {
    }

    public record CreateCityDto(
        [Required(ErrorMessage = "City Name is required")] string CityName,
        DateTime CreatedAt,
        DateTime UpdatedAt,
        string CityCode = " "
        );
    public record UpdateCityDto(
        [Required(ErrorMessage = "Id is required")] long Id,
        [Required(ErrorMessage = "City Name is required")] string CityName,
        bool IsActive,
        DateTime UpdatedAt,
        string CityCode = " "
        );
    public record GetCityDto(long Id, string CityName, string CityCode, bool IsActive);
}
