using System;
using ParkGuard.Dtos;
using ParkGuard.Models;

namespace api.Dtos.Location
{
        public class LocationDto
        {
                public int Id { get; set; }
                public required string City { get; set; }
                public required string Street { get; set; }
                public DateTime LastCheck { get; set; } 
                public int? GuardId { get; set; }

        }
}

