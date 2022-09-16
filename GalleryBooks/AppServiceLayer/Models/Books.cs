namespace AppServiceLayer.Models
{
    public class Books
    {
        
        public int Isbn { get; set; }
        
        public string BookName { get; set; }

       
        public string AuthorName { get; set; }
       
        public int TotalPages { get; set; }

        
        public string DescriptionUrl { get; set; }

       
        public string BookGenre { get; set; }
       
        public int PublisherId { get; set; }
        public string ImageUrl { get; set; }


    }
}
