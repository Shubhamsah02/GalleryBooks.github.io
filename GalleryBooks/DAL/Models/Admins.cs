using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Models
{
    public class Admins
    {
        [Key]
        public String EmailId { get; set; }

        public String Password { get; set; }
    }
}
