using JobPortal.Model.Company;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Model
{
    [Table("Designations")]
    [Index(nameof(DesignationName), IsUnique = true)]
    public class Designation : BaseEntity
    {
        [Required(ErrorMessage = "Designation Name is Required!")]
        [StringLength(100)]
        public string DesignationName { get; set; } = string.Empty;
        public string DesignationCode { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;

        /*public ICollection<JobPost> JobPosts { get; set; }*/
    }
}
