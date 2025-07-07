using System.ComponentModel.DataAnnotations.Schema;

namespace Inventar.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Serie { get; set; }
        public required int Year { get; set; }
        public required string Genre { get; set; }
        public int? Rating { get; set; }
        public DateTime? LastSeen { get; set; }
        public string? CoverImageUrl { get; set; }
        public string? TrailerUrl { get; set; }
        public string? Description { get; set; }

        [NotMapped]
        public string LastSeenDisplay => LastSeen?.ToShortDateString() ?? "-";
    }
}