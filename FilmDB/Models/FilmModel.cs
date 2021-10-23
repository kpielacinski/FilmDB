using System.ComponentModel.DataAnnotations;

namespace FilmDB.Models
{
    public class FilmModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Title { get; set; }

        public int Year { get; set; }
    }
}
