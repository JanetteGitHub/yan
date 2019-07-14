

namespace yan.Common.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class ServiciosyNegocios
    {
        [Key]
        public int ServiId { get; set; }
        [Required]
        [Display(Name = "Service Name")]
        public string ServiceName { get; set; }
        [Required]
        public string Adreess { get; set; }
        [Display(Name = "Page Contact")]
        public string PageContact { get; set; }
        public string Phone { get; set; }
        [Display(Name = "Publish On")]
        [DataType(DataType.Date)]
        public DateTime PublishOn { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Type Service ")]
        public string TypeService { get; set; }
        public string ImagePath { get; set; }

        public override string ToString()
        {
            return this.Description;
        }
    }
}
