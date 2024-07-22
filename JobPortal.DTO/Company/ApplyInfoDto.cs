using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.DTO.Company
{
    public class ApplyInfoDto
    {
        public record CreateApplyInfoDto(
            [Required(ErrorMessage = "User Id is Required")] long UserId,
            [Required(ErrorMessage = "Job Post Id is Required")] long JobPostId
        );

        public record GetApplyInfoDto(
            long Id,
            string Email,
            string JobDescription
        );

        public record UpdateApplyInfoDto(
            long Id,
            long UserId,
            long JobPostId
        );
    }
}
