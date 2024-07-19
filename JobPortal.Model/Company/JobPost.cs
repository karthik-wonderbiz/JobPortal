using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JobPortal.Model.Company
{
    [Table("JobPosts")]
    public class JobPost
    {
        [Required(ErrorMessage = "CompanyId is required")]
        [ForeignKey("Companies")]
        public long CompanyId { get; set; }
        public virtual CompanyInfo CompanyInfo { get; set; }

        [Required(ErrorMessage = "RecruiterId is required")]
        [ForeignKey("Recruiters")]
        public long RecruiterId { get; set; }
        public virtual Recruiter Recruiter { get; set; }

        [Required(ErrorMessage = "CompanyId is required")]
        [ForeignKey("Designations")]
        public long DesignationId { get; set; }
        public virtual Designation Designation { get; set; }


        [Required(ErrorMessage = "CompanyId is required")]
        [ForeignKey("Designations")]
        public long SkillId { get; set; }
        public virtual Skill Skill { get; set; }

        [Required(ErrorMessage = "TrainInfoId is required")]
        [ForeignKey("TrainLines")]
        public long TrainLineId { get; set; }
        public virtual TrainLine TrainLine { get; set; }

        [Required(ErrorMessage = "LanguageId is required")]
        [ForeignKey("Languages")]
        public long LanguageId { get; set; }
        public virtual Language Language { get; set; }

        [Required(ErrorMessage = "ShiftId is required")]
        [ForeignKey("Shifts")]
        public long ShiftId { get; set; }
        public virtual Shift Shift { get; set; }

        [Required(ErrorMessage = "WorkTypeId is required")]
        [ForeignKey("WorkTypes")]
        public long WorkTypeId { get; set; }
        public virtual WorkType WorkType { get; set; }

        [Required(ErrorMessage = "EmploymentTypeId is required")]
        [ForeignKey("EmploymentTypes")]
        public long EmploymentTypeId { get; set; }
        public virtual EmploymentType EmploymentType { get; set; }

        [Required(ErrorMessage = "EmploymentTypeId is required")]
        [ForeignKey("Qualifications")]
        public long QualificationId { get; set; }
        public virtual Qualification Qualification { get; set; }


        [Required(ErrorMessage = "Bond is required")]
        public bool Bond { get; set; } = true;


        [Required(ErrorMessage = "Job Description is required")]
        public string JobDescription { get; set; } = string.Empty;


        [Required(ErrorMessage = "Minimum Experience is required")]
        public int MinExperience { get; set; }


        [Required(ErrorMessage = "Maximum Experience is required")]
        public int MaxExperience { get; set; }

        [Required(ErrorMessage = "Minimum Salary is required")]
        public long MinSalary { get; set; }


        [Required(ErrorMessage = "Maximum Salary is required")]
        public long MaxSalary { get; set; }

        [Required(ErrorMessage = "Maximum Experience is required")]
        public int NoticePeriod { get; set; }


        [Required(ErrorMessage = "Maximum Salary is required")]
        public int Vacancy { get; set; }

        [Required(ErrorMessage = "Maximum Salary is required")]
        public DateTime ApplicationStartDate { get; set; }


        [Required(ErrorMessage = "Maximum Salary is required")]
        public DateTime ApplicationEndDate { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
