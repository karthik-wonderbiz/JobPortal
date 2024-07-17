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
    [Table("States")]
    [Index(nameof(StateName), IsUnique = true)]
    public class State : BaseEntity
    {
        [Required(ErrorMessage ="State Name is Required!")]
        [StringLength(100)]
        public string StateName { get; set; } = string.Empty;
        public string StateCode { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
}
