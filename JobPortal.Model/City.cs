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
    [Table("Cities")]
    [Index(nameof(CityName), IsUnique = true)]
    public class City : BaseEntity
    {
        [Required(ErrorMessage = "City Name is Required!")]
        [StringLength(100)]
        public string CityName { get; set; } = string.Empty;
        public string CityCode { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public ICollection<LocationInfo> LocationInfos { get; set; }
    }
}
