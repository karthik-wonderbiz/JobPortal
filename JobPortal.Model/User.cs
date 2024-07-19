using JobPortal.Model.Employee;
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
    [Table("Users")]
    [Index(nameof(Email), IsUnique = true)]
    public class User : BaseEntity
    {
        [Required(ErrorMessage = "Email is required")]
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required")]
        [StringLength(100)]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Contact is required")]
        public long Contact { get; set; } 
        public bool IsActive { get; set; } = true;
        
        public ICollection<SkillInfo> SkillInfos { get; set; }
        public ICollection<LocationInfo> LocationInfos { get; set; }
        public ICollection<Publication> Publications { get; set; }
        public ICollection<LanguageInfo> LanguageInfos { get; set; }
    }
}
