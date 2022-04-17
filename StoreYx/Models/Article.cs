using System.ComponentModel.DataAnnotations;

namespace StoreYx.Models
{
    public class Article
    {
        public int Id { get; set; }

        [Required]
        public string? Title { get; set; }
        public string? Description { get; set; }

        public string? Author { get; set; }
       

        [Required]
        public string? Body { get; set; }

        public string? Tags { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedAt { get; set; }

    }
}
