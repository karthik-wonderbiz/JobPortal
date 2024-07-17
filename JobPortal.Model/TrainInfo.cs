using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Model
{
    [Table("TrainInfos")]
    [Index(nameof(TrainInfoName), IsUnique = true)]
    public class TrainInfo : BaseEntity
    {
        [Required(ErrorMessage ="Train Info Name is required.")]
        [StringLength(100)]
        public string TrainInfoName { get; set; } = string.Empty;

        public string TrainInfoCode { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;
    }
}
