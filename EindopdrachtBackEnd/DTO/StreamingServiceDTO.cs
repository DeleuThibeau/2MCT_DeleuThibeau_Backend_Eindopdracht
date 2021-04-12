using System;
using System.Collections.Generic;

namespace EindopdrachtBackEnd.DTO
{
    public class StreamingServiceDTO
    {
        public int StreamingServiceId { get; set; }
        public string Name { get; set; }
        public bool IsLegal { get; set; }
        public List<int> DeviceStreamingServices { get; set; }
    }
}
