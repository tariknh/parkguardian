namespace ParkGuard.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public DateTime LastCheck { get; set; } 
        public int? GuardId { get; set; }
        public Guard? Guard { get; set; }
    }
}