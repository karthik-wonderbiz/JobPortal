using JobPortal.Model.Company;
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
    [Table("Languages")]
    [Index(nameof(LanguageName),IsUnique = true)]
    public class Language : BaseEntity
    {
        [Required(ErrorMessage = "Language Name is Required")]
        [MaxLength(50)]
        public string LanguageName { get; set; } = string.Empty;

        [MaxLength(50)]
        public string LanguageCode { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public ICollection<LanguageInfo> languageInfos { get; set; }
        public ICollection<JobPost> JobPosts { get; set; }
    }
}
