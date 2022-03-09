using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalEve.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        [StringLength(50, MinimumLength = 2)]
        [Display(Name = "OrderItem")]
        [Required(ErrorMessage = "Item can not be blank")]
        public string Item { get; set; }

        [Required(ErrorMessage = " Plz Inter your Value")]
        [Range(5, 100, ErrorMessage = "Age Must be between 5 to 100")]
        public double Total { get; set; }
        [Required]
        [Display(Name = "Creation Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime OrderDate { get; set; }
        [Required]
        public bool IsAvailable { get; set; }
        [Required]
        public string Picture { get; set; }

        [NotMapped]
        public HttpPostedFileBase PictureUrl { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }


    }
}