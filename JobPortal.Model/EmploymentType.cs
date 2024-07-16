using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Model
{
    [Table("EmploymentTypes")]
    public class EmploymentType : BaseEntity
    {
        [Required]
        public string EmploymentTypeName { get; set; }

        public string EmploymentTypeCode { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;
    }
}
