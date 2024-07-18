using JobPortal.Model.Employee;
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
    [Table("Countries")]
    [Index(nameof(CountryName), IsUnique = true)]
    public class Country : BaseEntity
    {
        [Required(ErrorMessage = "Country Name is required")]
        [StringLength(100)]
        public string CountryName { get; set; } = string.Empty;

        public string CountryCode { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;
        public ICollection<LocationInfo> LocationInfos { get; set; }
    }
}
