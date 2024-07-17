using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.DTO
{
    public class WorkTypeDto
    {
        public record CreateWorkTypeDto(
            [Required(ErrorMessage = "WorkTypeName is required")] string WorkTypeName,
            DateTime CreatedAt,
            DateTime UpdatedAt,
            string WorkTypeCode = " "
        );
        public record GetWorkTypeDto(
            long Id,
            string WorkTypeName,
            string WorkTypeCode,
            bool IsActive
        );
        public record UpdateWorkTypeDto(
            [Required(ErrorMessage = "Id is required")] long Id,
            [Required(ErrorMessage = "WorkTypeName is required")] string WorkTypeName,
            bool IsActive,
            DateTime UpdatedAt,
            string WorkTypeCode = " "
        );
    }
}
