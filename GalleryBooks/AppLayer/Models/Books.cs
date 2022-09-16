using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AppLayer.Models
{
    public class Books
    {
        [Key]
        public int ISBN { get; set; }
        public String BookName { get; set; }
        public String AuthorName { get; set; }
        public int TotalPages { get; set; }
        public string DescriptionUrl { get; set; }
        public Genre BookGenre { get; set; }

        public int? PublisherId { get; set; }
        public string ImageUrl { get; set; }
    }
}
