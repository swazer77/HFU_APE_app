using System;

namespace MovieInventoryApp.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public double Rating { get; set; }
        public DateTime LastSeen { get; set; }
        public string CoverImageUrl { get; set; }
        public string TrailerUrl { get; set; }
        public string Description { get; set; }
    }
}