using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Model
{
    public class Language : BaseEntity
    {
        [Required(ErrorMessage = "Language Name is Required")]
        public string LanguageName { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
