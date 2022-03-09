using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalEve.Models
{
    public class UserInfo
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Fill the box")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Fill the box")]

        public string Password { get; set; }
    }
}