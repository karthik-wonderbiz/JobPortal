using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace JobPortal.Model
{
    [Table("Publications")]
    public class Publication : BaseEntity
    {
        [Required(ErrorMessage = "UserId is required")]
        [ForeignKey("Users")]
        public long UserId { get; set; }

        public virtual User User { get; set; }

        [Required(ErrorMessage = "Publication Title is required")]
        [StringLength(100)]
        public string PublicationTitle { get; set; } = string.Empty;

        [Required(ErrorMessage = "Publisher Name is required")]
        [StringLength(100)]
        public string PublisherName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Publish Date is required")]
        public DateTime PublishDate { get; set; }

        [Required(ErrorMessage = "Publication URL is required")]
        [StringLength(100)]
        public string PublicationURL { get; set; } = string.Empty ;

        [Required(ErrorMessage = "Description is required")]
        [StringLength(100)]
        public string Description { get; set; } = string.Empty; 

        public bool IsActive { get; set; } = true;
    }
}
