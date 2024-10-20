using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Location;
using ParkGuard.Models;

namespace ParkGuard.Dtos.Guard
{
    public class UpdateGuardRequestDto
    {
        [Required]
        [MaxLength(10, ErrorMessage = "First Name Cannot be longer than 10 characters")]
        public string FirstName { get; set; }
        
        [Required]
        [MaxLength(10, ErrorMessage = "Last Name Cannot be longer than 10 characters")]
        public string LastName { get; set; }

        public List<LocationDto> ? CheckedLocations { get; set; }

    }
}