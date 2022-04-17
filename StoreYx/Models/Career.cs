using System.ComponentModel.DataAnnotations;

namespace StoreYx.Models
{
    public class Career
    {
        public int Id { get; set; }

        [Required]
        public string? Title { get; set; }
        public string? Description { get; set; }

        [Required]
        public string? Body { get; set; }

        public Boolean IsAvailable { get; set; } = true;


        [DataType(DataType.Date)]
        public DateTime CreatedAt { get; set; }

    }
}
