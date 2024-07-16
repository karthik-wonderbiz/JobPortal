using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Model
{
    [Table("Countries")]
    public class Country : BaseEntity
    {
        [Required]
        public string CountryName { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
