using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.DTO.Employee
{
    public class CertificationInfoDto
    {
        public record CreateCertificationInfoDto(
            [Required] long UserId,
            [Required] string CertficateName,
            [Required] string OrganisationName,
            [Required] DateTime IssueDate,
            DateTime ExpiryDate,
            string SkillAcquired,
            string CertificateURL
        );
        public record GetCertificationInfoDto(
            long Id,
            string Email,
            string CertficateName,
            string OrganisationName,
            DateTime IssueDate,
            DateTime ExpiryDate,
            string SkillAcquired,
            string CertificateURL
        );
        public record UpdateCertificationInfoDto(
            long Id,
            long UserId,
            string CertficateName,
            string OrganisationName,
            DateTime IssueDate,
            DateTime ExpiryDate,
            string SkillAcquired,
            string CertificateURL
        );
    }
}
