using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Model
{
    [Table("States")]
    public class State : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string StateName { get; set; }
        public string StateCode { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
}
