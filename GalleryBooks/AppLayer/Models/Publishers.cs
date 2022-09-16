using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AppLayer.Models
{
    public class Publishers
    {
        [Key]
        public int? PublisherId { get; set; }
        public String PublishersName { get; set; }

        public String Email { get; set; }

    }
}
