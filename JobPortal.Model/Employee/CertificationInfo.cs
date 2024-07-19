using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Model.Employee
{
    public class CertificationInfo : BaseEntity
    {
        public virtual User User { get; set; }
        [ForeignKey("Users"), Required(ErrorMessage = "User Id is Required")]
        public long UserId { get; set; }

        [Required(ErrorMessage = "Certification Name is Required")]
        public string CertficateName { get; set; }

        [Required(ErrorMessage = "Organisation Name is Required")]
        public string OrganisationName { get; set; }

        [Required(ErrorMessage = "Issue Date is Required")]
        public DateTime IssueDate { get; set; }

        public DateTime ExpiryDate { get; set; }

        public string SkillAcquired { get; set; }

        public string CertificateURL { get; set; }
    }
}
