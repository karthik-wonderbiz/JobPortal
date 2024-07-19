using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Model.Employee
{
    [Table("WorkExperienceInfos")]
    public class WorkExperienceInfo : BaseEntity
    {
        public virtual User User { get; set; }
        [ForeignKey("Users"), Required(ErrorMessage = "User Id is Required")]
        public long UserId { get; set; }

        public virtual WorkType WorkType { get; set; }
        [ForeignKey("WorkTypes"), Required(ErrorMessage = "WorkType Id is Required")]
        public long WorkTypeId { get; set; }

        public virtual EmploymentType EmploymentType { get; set; }
        [ForeignKey("EmploymentTypes"), Required(ErrorMessage = "EmploymentType Id is Required")]
        public long EmploymentTypeId { get; set; }

        public virtual Designation Designation { get; set; }
        [ForeignKey("Designations"), Required(ErrorMessage = "Designation Id is Required")]
        public long DesignationId { get; set; }

        [Required(ErrorMessage = "Company Name is Required")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Start Date is Required")]
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string SkillsUsed { get; set; }
    }
}
