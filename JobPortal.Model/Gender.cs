using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Model
{
    [Table("Genders")]
    public class Gender : BaseEntity
    {
        [Required(ErrorMessage = "GenderName is required")]
        public string GenderName { get; set; }
        public string GenderCode { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
