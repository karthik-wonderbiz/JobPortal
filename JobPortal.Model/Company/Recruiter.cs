using JobPortal.Model.Company;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Model.Company
{
    [Table("Recruiters")]
    [Index(nameof(RecruiterEmail), IsUnique = true)]
    [Index(nameof(RecruiterPhone), IsUnique = true)]
    public class Recruiter : BaseEntity
    {
        [ForeignKey("Companies"), Required(ErrorMessage = "Company Id is required!")]
        public long CompanyId { get; set; }
        public virtual CompanyInfo CompanyInfo { get; set; } = new CompanyInfo();
        [Required(ErrorMessage = "Recruiter Name is required!")]
        [StringLength(100)]
        public string RecruiterName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Recruiter Phone Number is required!")]
        [MaxLength(100)]
        public long RecruiterPhone { get; set; }
        [Required(ErrorMessage = "Recruiter Email is required!")]
        [StringLength(100)]
        public string RecruiterEmail { get; set; } = string.Empty;

        public ICollection<JobPost> JobPosts { get; set; }
    }
}