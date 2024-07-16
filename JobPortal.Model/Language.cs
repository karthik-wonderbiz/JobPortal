using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Model
{
    [Table("Languages")]
    public class Language : BaseEntity
    {
        [Required(ErrorMessage = "Language Name is Required")]
        [MaxLength(50)]
        public string LanguageName { get; set; }

        [MaxLength(50)]
        public string LanguageCode { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
