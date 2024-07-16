using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.DTO
{
    public class LanguageDto
    {
        public record CreateLanguageDto(
            [Required(ErrorMessage = "LanguageName is required")] string LanguageName, 
            DateTime CreatedAt, 
            DateTime UpdatedAt, 
            string LanguageCode = " "
        );
        public record GetLanguageDto(
            long Id, 
            string LanguageName, 
            string LanguageCode, 
            bool IsActive
        );
        public record UpdateLanguageDto(
            [Required(ErrorMessage = "Id is required")] long Id,
            [Required(ErrorMessage = "LanguageName is required")] string LanguageName,
            bool IsActive,
            DateTime UpdatedAt,
            string LanguageCode = " "
        );
    }
}
