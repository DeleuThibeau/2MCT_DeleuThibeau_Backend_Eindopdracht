using System;
using System.Collections.Generic;
using EindopdrachtBackEnd.Models;

namespace EindopdrachtBackEnd.DTO
{
    public class AllAnimeDTO
    {
        public string URLImage { get; set; }
        public string Name { get; set; }
        public string Synopsis { get; set; }
        public int Rating { get; set; }

        public int StudioId { get; set; }
        public int GenreId { get; set; }

    }
}
