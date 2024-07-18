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
    [Table("Skills")]
    [Index(nameof(SkillName), IsUnique = true)]
    public class Skill : BaseEntity
    {
        [Required(ErrorMessage = "Skill Name is Required")]
        public string SkillName { get; set; } = string.Empty;

        public string SkillCode { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;

        public ICollection<SkillInfo> SkillInfos { get; set; }
    }
}
