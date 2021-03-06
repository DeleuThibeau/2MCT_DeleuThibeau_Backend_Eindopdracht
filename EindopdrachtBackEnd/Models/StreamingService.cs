using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EindopdrachtBackEnd.Models
{
    public class StreamingService
    {
        public int StreamingServiceId { get; set; }
        public string Name { get; set; }
        public bool IsLegal { get; set; }

        public DateTime YearOfRelease { get; set; }

        public List<AnimeStreamingService> AnimeStreamingServices { get; set; }

    }
}
