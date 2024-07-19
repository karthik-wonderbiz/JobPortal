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
    [Table("Companies")]
    [Index(nameof(CompanyName), IsUnique = true)]
    [Index(nameof(CompanyEmail), IsUnique = true)]
    [Index(nameof(CompanyPhone), IsUnique = true)]
    public class CompanyInfo : BaseEntity
    {
        [ForeignKey("Users"), Required(ErrorMessage = "User Id is required!")]
        public long UserId { get; set; }
        public virtual User User { get; set; }
        public string CompanyLogo { get; set; } = string.Empty;
        [Required(ErrorMessage = "Company Description is required!")]
        [StringLength(100)]
        public string CompanyDescription { get; set; } = string.Empty;
        [Required(ErrorMessage = "Company Name is required!")]
        [StringLength(100)]
        public string CompanyName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Company Phone Number is required!")]
        [MaxLength(100)]
        public long CompanyPhone { get; set; }
        [Required(ErrorMessage = "Company Email is required!")]
        [StringLength(100)]
        public string CompanyEmail { get; set; } = string.Empty;
        public string CompanyWebsite { get; set; } = string.Empty;
        public string CompanyDomain { get; set; } = string.Empty;
        public string WorkingDays { get; set; } = string.Empty;
        public string OpenHours { get; set; } = string.Empty;

    }
}