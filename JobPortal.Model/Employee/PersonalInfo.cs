using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Model.Employee
{
    [Table("PersonalInfos")]
    public class PersonalInfo : BaseEntity
    {
        public virtual User User { get; set; }

        [ForeignKey("Users"), Required(ErrorMessage = "User ID is required")]
        public long UserId { get; set; }
        public virtual Gender Gender { get; set; }

        [ForeignKey("Gender"), Required(ErrorMessage = "Gender ID  is required")]
        public long GenderId { get; set; }

        public string ProfilePic { get; set; } = string.Empty;

        [Required(ErrorMessage = "First Name is Required")]
        [MaxLength(50)]
        public string FirstName = string.Empty;

        [Required(ErrorMessage = "Last Name is Required")]
        [MaxLength(50)]
        public string LastName = string.Empty;

    }
}
