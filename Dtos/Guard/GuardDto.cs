using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Location;
using ParkGuard.Models;

namespace ParkGuard.Dtos
{
    public class GuardDto
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }

        public List<LocationDto> ? CheckedLocations { get; set; }
    }
}