using System;

namespace EindopdrachtBackEnd.Models
{
    public class AnimeStreamingService
    {
        public Guid AnimeId { get; set; }
        
        public int StreamingServiceId { get; set; }
        public StreamingService StreamingService { get; set; }
    }
}
