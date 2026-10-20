using System;

namespace DatorsalsBokningen.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Purpose { get; set; }
    }
}
