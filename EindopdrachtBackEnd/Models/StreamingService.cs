using System;

namespace EindopdrachtBackEnd.Models
{
    public class StreamingService
    {
        public int StreamingServiceId { get; set; }
        public string Name { get; set; }
        public Device Device { get; set; }

        public bool IsLegal { get; set; }
    }
}
