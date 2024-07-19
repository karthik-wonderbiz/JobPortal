using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Model.Employee
{
    [Table("LocationInfo")]
    public class LocationInfo : BaseEntity
    {
        public virtual User User { get; set; }
        [ForeignKey("Users"), Required(ErrorMessage = "User Id is Required")]
        public long UserId { get; set; }

        public virtual City City { get; set; }
        [ForeignKey("Cities"), Required(ErrorMessage = "City Id is Required")]
        public long CityId { get; set; }

        public virtual State State { get; set; }
        [ForeignKey("States"), Required(ErrorMessage = "State Id is Required")]
        public long StateId { get; set; }

        public virtual Country Country { get; set; }
        [ForeignKey("Countries"), Required(ErrorMessage = "Country Id is Required")]
        public long CountryId { get; set; }

        public virtual TrainInfo TrainInfo { get; set; }
        [ForeignKey("TrainInfo"), Required(ErrorMessage = "Train Line Id is Required")]
        public long TrainInfoId { get; set; }

        [Required(ErrorMessage = "Address Line 1 is Required")]
        public string AddressLine1 { get; set; } = string.Empty;

        public string AddressLine2 { get; set; } = string.Empty;

        public long ZipCode { get; set; }
    }
}
