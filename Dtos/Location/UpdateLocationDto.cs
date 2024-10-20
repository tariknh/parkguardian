using System;
using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Location
{
     public class UpdateLocationDto
        {
            [MinLength(5, ErrorMessage = "Min length is 5")]
            [MaxLength(280, ErrorMessage = "Street cannot be longer than 280 chars" )]
            public string? City { get; set; } 
            [MinLength(5, ErrorMessage = "Min length is 5")]
            [MaxLength(280, ErrorMessage = "Street cannot be longer than 280 chars" )]
            public string? Street { get; set; } 
            public DateTime? LastCheck { get; set; } 
            public int? GuardId { get; set; }
        };
};