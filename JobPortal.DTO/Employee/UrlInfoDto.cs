using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.DTO.Employee
{
    public class UrlInfoDto
    {
        public record CreateUrlInfoDto(
            [Required] long UserId,
            [Required] long UrlNameId,
            [Required] string UrlValue
        );
        public record GetUrlInfoDto(
            long Id,
            string Email,
            string UrlName,
            string UrlValue
        );
        public record UpdateUrlInfoDto(
            long Id,
            long UserId,
            long UrlNameId,
            string UrlValue
        );
    }
}
