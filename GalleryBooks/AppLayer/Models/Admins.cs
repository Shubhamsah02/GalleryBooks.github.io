using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AppLayer.Models
{
    public class Admins
    {
        [Key]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e-mail adress")]
        [Required(ErrorMessage = "Email is required")]
        public String EmailId { get; set; }


        [StringLength(maximumLength: 50)]
        [Required(ErrorMessage = "Password  is required")]
        public String Password { get; set; }
    }
}
