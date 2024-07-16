using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Data
{
    public class TrainInfoDto
    {
    }

    public record CreateTrainInfoDto([Required(ErrorMessage = "TrainInfoName is required")] string TrainInfoName, DateTime CreatedAt, DateTime UpdatedAt, string TrainInfoCode = " ");
    public record UpdateTrainInfoDto([Required(ErrorMessage = "Id is required")] int Id, [Required(ErrorMessage = "TrainInfoName is required")] string TrainInfoName, bool IsActive, DateTime UpdatedAt, string TrainInfoCode = " ");
    public record GetTrainInfoDto(long Id, string TrainInfoName, string TrainInfoCode, bool IsActive);
}
