using System;
using System.ComponentModel.DataAnnotations;
using ParkGuard.Dtos;
using ParkGuard.Models;

namespace api.Dtos.Location
{
    public class CreateLocationRequestDto
    {  
            [Required]
            [MinLength(5, ErrorMessage = "Min length is 5")]
            [MaxLength(280, ErrorMessage = "City cannot be longer than 280 chars" )]
            public required string City { get; set; } = string.Empty;

            [MinLength(5, ErrorMessage = "Min length is 5")]
            [MaxLength(280, ErrorMessage = "Street cannot be longer than 280 chars" )]
            public required string Street { get; set; }  = string.Empty;

        
            public DateTime? LastCheck { get; set; } 

            public int? GuardId { get; set; }
        
    }
}

