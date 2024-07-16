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
    public class TrainInfo : BaseEntity
    {
        [Required]
        public string TrainInfoName { get; set; }

        public string TrainInfoCode { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;
    }
}
