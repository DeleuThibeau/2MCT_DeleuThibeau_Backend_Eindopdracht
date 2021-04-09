using System;
using System.Collections.Generic;

namespace EindopdrachtBackEnd.Models
{
    public class Anime
    {
        public Guid AnimeId { get; set; }
        public string URLImage { get; set; }
        public string Name { get; set; }
        public string Synopsis { get; set; }
        public int Rating { get; set; }
        public int StudioId { get; set; }
        public Studio Studio { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }

        public List<AnimeStreamingService> AnimeStreamingServices { get; set; }
    }
}
