using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Model.Employee
{
    [Table("UrlInfos")]
    public class UrlInfo : BaseEntity
    {
        public virtual User User { get; set; }
        [ForeignKey("Users"), Required(ErrorMessage = "User Id is Required")]
        public long UserId { get; set; }

        public virtual UrlName UrlName { get; set; }

        [ForeignKey("UrlNames"), Required(ErrorMessage = "UrlName Id is Required")]
        public long UrlNameId { get; set; }

        [Required(ErrorMessage = "Skill Experience is Required")]
        public string UrlValue { get; set; }
    }
}
