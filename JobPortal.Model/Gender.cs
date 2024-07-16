using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Model
{
    public class Gender : BaseEntity
    {
        [Required(ErrorMessage = "GenderName is required")]
        public string GenderName { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
