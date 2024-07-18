using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.DTO.Employee
{
    public class LanguageInfoDto
    {
        public record CreateLanguageInfoDto(
            [Required(ErrorMessage = "User Id is Required")] long UserId,
            [Required(ErrorMessage = "Language Id is Required")] long LanguageID
        );

        public record GetLanguageInfoDto(
            long Id,
            string Email,
            string LanguageName      
        );

        public record UpdateLanguageInfoDto(
            long Id,
            long UserId,
            long LanguageID
        );
    }
}
