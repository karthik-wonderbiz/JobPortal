using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Model
{
    [Table("Shifts")]
    public class Shift : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string ShiftName { get; set; }
        public string ShiftCode { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
}
