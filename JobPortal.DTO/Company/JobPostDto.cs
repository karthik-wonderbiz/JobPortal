using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.DTO.Company
{
    public class JobPostDto
    {
    }

    public record CreateJobPostDto(
        [Required(ErrorMessage = "CompanyId is required")] long CompanyId,
        [Required(ErrorMessage = "RecruiterId is required")] long RecruiterId,
        [Required(ErrorMessage = "DesignationId is required")] long DesignationId,
        [Required(ErrorMessage = "SkillId is required")] long SkillId,
        [Required(ErrorMessage = "TrainLineId is required")] long TrainLineId,
        [Required(ErrorMessage = "LanguageId is required")] long LanguageId,
        [Required(ErrorMessage = "ShiftId is required")] long ShiftId,
        [Required(ErrorMessage = "WorkTypeId is required")] long WorkTypeId,
        [Required(ErrorMessage = "EmploymentTypeId is required")] long EmploymentTypeId,
        [Required(ErrorMessage = "QualificationId is required")] long QualificationId,
        [Required(ErrorMessage = "Bond is required")] bool Bond,
        [Required(ErrorMessage = "JobDescription is required")] string JobDescription,
        [Required(ErrorMessage = "MinExperience is required")] int MinExperience,
        [Required(ErrorMessage = "MaxExperience is required")] int MaxExperience,
        [Required(ErrorMessage = "MinSalary is required")] long MinSalary,
        [Required(ErrorMessage = "MaxSalary is required")] long MaxSalary,
        [Required(ErrorMessage = "NoticePeriod is required")] int NoticePeriod,
        [Required(ErrorMessage = "Vacancy is required")] int Vacancy,
        [Required(ErrorMessage = "ApplicationStartDate is required")] DateTime ApplicationStartDate,
        [Required(ErrorMessage = "ApplicationEndDate is required")] DateTime ApplicationEndDate,
        bool IsActive,
        DateTime CreatedAt,
        DateTime UpdatedAt
        );
    public record UpdateJobPostDto(
        long CompanyId,
        long RecruiterId,
        long DesignationId,
        long SkillId,
        long TrainLineId,
        long LanguageId,
        long ShiftId,
        long WorkTypeId,
        long EmploymentTypeId,
        long QualificationId,
        bool Bond,
        string JobDescription,
        int MinExperience,
        int MaxExperience,
        long MinSalary,
        long MaxSalary,
        int NoticePeriod,
        int Vacancy,
        DateTime ApplicationStartDate,
        DateTime ApplicationEndDate,
        bool IsActive,
        DateTime CreatedAt,
        DateTime UpdatedAt
        );
    public record GetJobPostDto(
        string CompanyName,
        string CompanyLogo,
        string RecruiterName,
        long RecruiterPhone,
        string RecruiterEmail,
        string DesignationName,
        string SkillName,
        string TrainLineName,
        string LanguageName,
        string ShiftName,
        string WorkTypeName,
        string EmploymentTypeName,
        string QualificationName,
        bool Bond,
        string JobDescription,
        int MinExperience,
        int MaxExperience,
        long MinSalary,
        long MaxSalary,
        int NoticePeriod,
        int Vacancy,
        DateTime ApplicationStartDate,
        DateTime ApplicationEndDate,
        bool IsActive
        );
}
