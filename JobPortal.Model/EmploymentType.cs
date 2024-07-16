using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Model
{
    public class EmploymentType : BaseEntity
    {
        [Required]
        public string EmploymentTypeName { get; set; }

        public string EmploymentTypeCode { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
