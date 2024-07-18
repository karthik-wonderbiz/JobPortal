using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Model.Employee
{
    [Table("Educations")]
    public class Education : BaseEntity
    {
        public virtual User User { get; set; }

        [ForeignKey("Users"),Required(ErrorMessage = "User ID is required")]
        public long UserId { get; set; }
        public virtual Qualification Qualification { get; set; }

        [ForeignKey("Qualifications"),Required(ErrorMessage = "Qualification ID  is required")]
        public long QualificationId { get; set; }

        [Required(ErrorMessage = "Institute Name is required")]
        [MaxLength(50)]
        public string InstituteName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Board or University Name is required")]
        [MaxLength(50)]
        public string BoardOrUniversityName { get; set; } = string.Empty;

        [Required(ErrorMessage = "degree Name is required")]
        [MaxLength(50)]
        public string DegreeName { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }   
        public float GradeOrPercentage { get; set; }











    }
}
