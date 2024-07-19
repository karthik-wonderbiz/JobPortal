using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Data
{
    public class TrainLineDto
    {
    }

    public record CreateTrainLineDto([Required(ErrorMessage = "TrainLineName is required")] string TrainLineName, DateTime CreatedAt, DateTime UpdatedAt, string TrainLineCode = " ");
    public record UpdateTrainLineDto([Required(ErrorMessage = "Id is required")] int Id, [Required(ErrorMessage = "TrainLineName is required")] string TrainLineName, bool IsActive, DateTime UpdatedAt, string TrainLineCode = " ");
    public record GetTrainLineDto(long Id, string TrainLineName, string TrainLineCode, bool IsActive);
}
