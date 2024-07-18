using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Model.Employee
{
    [Table("SkillInfo")]
    public class SkillInfo : BaseEntity
    {
        public virtual User User { get; set; }

        [ForeignKey("Users"), Required(ErrorMessage = "User Id is Required")]
        public long UserId { get; set; }

        public virtual Skill Skill { get; set; }

        [ForeignKey("Skills"), Required(ErrorMessage = "Skill Id is Required")]
        public long SkillId { get; set; }

        [Required(ErrorMessage = "Skill Experience is Required")]
        public int SkillExperience { get; set; } = 0;
    }
}
