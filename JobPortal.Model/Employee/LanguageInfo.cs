using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Model.Employee
{
    [Table("LanguageInfos")]
    public class LanguageInfo : BaseEntity
    {
        public virtual Language Language { get; set; }

        [ForeignKey("Languages"),Required(ErrorMessage = "Language Id is Required")]
        public long LanguageId { get; set; }

        public virtual User User { get; set; }  

        [ForeignKey("Users"),Required(ErrorMessage = "User Id is Required")]
        public long UserId { get; set; }


    }
}
