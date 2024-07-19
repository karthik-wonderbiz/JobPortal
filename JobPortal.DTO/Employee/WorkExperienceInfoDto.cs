using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.DTO.Employee
{
    public class WorkExperienceInfoDto
    {
        public record CreateWorkExperienceInfoDto(
            [Required] long UserId,
            [Required] long WorkTypeId,
            [Required] long EmploymentTypeId,
            [Required] long DesignationId,
            [Required] string CompanyName,
            DateTime StartDate,
            DateTime EndDate,
            string SkillsUsed
        );
        public record GetWorkExperienceInfoDto(
            long Id,
            string Email,
            string WorkType,
            string EmploymentType,
            string Designation,
            string CompanyName,
            DateTime StartDate,
            DateTime EndDate,
            string SkillsUsed
        );
        public record UpdateWorkExperienceInfoDto(
            long Id,
            long UserId,
            long WorkTypeId,
            long EmploymentTypeId,
            long DesignationId,
            string CompanyName,
            DateTime StartDate,
            DateTime EndDate,
            string SkillsUsed
        );
    }
}
