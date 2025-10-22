using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dtos
{
    public class LocationDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string? Contact { get; set; }
        public string? OpeningAt { get; set; }
        public string? ClosingAt { get; set; }
        public int? Capacity { get; set; }
        public string? Description { get; set; }
        public string? ImagePath { get; set; }
    }
}
