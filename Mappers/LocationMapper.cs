using System;
using api.Dtos.Location;
using Microsoft.CodeAnalysis;
using ParkGuard.Dtos;
using ParkGuard.Mappers;
using ParkGuard.Models;
using Location = ParkGuard.Models.Location;

namespace TodoApi.Mappers;

public static class LocationMapper
{
    public static LocationDto ToLocationDto(this Location locationModel)
    {
        return new LocationDto
        {
            Id = locationModel.Id,
            City = locationModel.City,
            Street = locationModel.Street,
            LastCheck = locationModel.LastCheck,
            GuardId = locationModel?.GuardId,
        };
    }
    public static Location ToLocationFromCreateDto(this CreateLocationRequestDto locationDto)
    {
        return new Location
        {
  
            City = locationDto.City,
            Street = locationDto.Street,
            GuardId = locationDto?.GuardId,
           
        };
    }
    public static Location ToLocationFromDto(this LocationDto locationDto){
        return new Location
        {
            Id = locationDto.Id,
            City = locationDto.City,
            Street = locationDto.Street,
            LastCheck = locationDto.LastCheck,
            GuardId = locationDto?.GuardId,
        };
    }
}
