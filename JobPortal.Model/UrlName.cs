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
    [Table("UrlNames")]
    [Index(nameof(URLName), IsUnique = true)]
    public class UrlName : BaseEntity
    {
        [Required(ErrorMessage = "URL Name is Required")]
        [MaxLength(50)]
        public string URLName { get; set; } = string.Empty;

        [MaxLength(50)]
        public string URLCode { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
}
