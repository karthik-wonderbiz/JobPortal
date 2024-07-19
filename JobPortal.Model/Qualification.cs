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
    [Table("Qualifications")]
    [Index(nameof(QualificationName), IsUnique = true)]
    public class Qualification : BaseEntity
    {
        [Required(ErrorMessage = "Qualification Name is Required")]
        [MaxLength(50)]
        public string QualificationName { get; set; } = string.Empty;

        [MaxLength(50)]
        public string QualificationCode { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;

        /*public ICollection<JobPost> JobPosts { get; set; }*/
    }
}
