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
    [Table("ContactPersons")]
    [Index(nameof(ContactPersonEmail), IsUnique = true)]
    [Index(nameof(ContactPersonPhone), IsUnique = true)]
    public class ContactPersonInfo : BaseEntity
    {
        [ForeignKey("Companies"), Required(ErrorMessage = "Company Id is required!")]
        public long CompanyId { get; set; }
        public virtual CompanyInfo CompanyInfo { get; set; } = new CompanyInfo();
        [Required(ErrorMessage = "Contact Person Name is required!")]
        [StringLength(100)]
        public string ContactPersonName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Contact Person Phone Number is required!")]
        [MaxLength(100)]
        public long ContactPersonPhone { get; set; }
        [Required(ErrorMessage = "Contact Person Email is required!")]
        [StringLength(100)]
        public string ContactPersonEmail { get; set; } = string.Empty;
    }
}