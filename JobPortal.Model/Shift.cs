using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Model
{
    public class Shift : BaseEntity
    {

        [Required]
        [StringLength(100)]
        public string ShiftName { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
