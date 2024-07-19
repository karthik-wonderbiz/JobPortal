using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Model.Employee
{
    [Table("Projects")]
    public class Project : BaseEntity
    {
        public virtual User User { get; set; }

        [ForeignKey("Users"), Required(ErrorMessage = "User ID is required")]
        public long UserId { get; set; }

        [Required(ErrorMessage = "Project Title is required")]
        [MaxLength(50)]
        public string ProjectTitle { get; set; } = string.Empty;

        [Required(ErrorMessage = "Project Description is required")]
        [MaxLength(50)]
        public string ProjectDescription { get; set; } = string.Empty;

        [Required(ErrorMessage = "Skills is required")]
        [MaxLength(50)]
        public string Skills { get; set; } = string.Empty;
        public DateTime ExpiryDate { get; set; }
        public string Contributor { get; set; } = string.Empty;
        public string ProjectUrl { get; set; } = string.Empty;
    }
}
