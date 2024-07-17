using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.DTO
{
    public class UrlNameDto
    {
        public record CreateUrlNameDto(
            [Required(ErrorMessage = "URL Name is required")] string UrlName,
            DateTime CreatedAt,
            DateTime UpdatedAt,
            string UrlCode = " "
        );
        public record GetUrlNameDto(
            long Id,
            string UrlName,
            string UrlCode,
            bool IsActive
        );
        public record UpdateUrlNameDto(
            [Required(ErrorMessage = "Id is required")] long Id,
            [Required(ErrorMessage = "UrlNameName is required")] string UrlName,
            bool IsActive,
            DateTime UpdatedAt,
            string UrlCode = " "
        );
    }
}
