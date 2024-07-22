using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Model.Company
{
    [Table("ApplyInfos")]
    public class ApplyInfo : BaseEntity
    {
        public virtual JobPost JobPost { get; set; }

        [ForeignKey("JobPosts"), Required(ErrorMessage = "JobPost Id is Required")]
        public long JobPostId { get; set; }

        public virtual User User { get; set; }

        [ForeignKey("Users"), Required(ErrorMessage = "User Id is Required")]
        public long UserId { get; set; } = 0;
    }
}
