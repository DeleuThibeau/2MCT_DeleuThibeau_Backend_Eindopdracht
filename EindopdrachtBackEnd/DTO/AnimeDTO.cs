using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EindopdrachtBackEnd.Models;

namespace EindopdrachtBackEnd.DTO
{
    public class AnimeDTO
    {
        public Guid AnimeId {get; set;}
        [Required(ErrorMessage = "Every show has a poster you know! Please make sure to fill in the image field!")]
        public string URLImage { get; set; }

        [Required(ErrorMessage = "Every show has a name you know! Please make sure to fill in the name field!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Every show has a story to tell, let the people know what it's about with the synopsis field!")]
        public string Synopsis { get; set; }
        public int Rating { get; set; }
        public int StudioId { get; set; }
        public int GenreId { get; set; }

         [Required(ErrorMessage = "A show is available on some platforms someone you know! Please make sure to mention where you can watch it! (work with animeStreamings objects => can be found on animeStreamingService.cs)")]
        public List<int> AnimeStreamingServices { get; set; }
    }
}
