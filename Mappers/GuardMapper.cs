using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ParkGuard.Dtos;
using ParkGuard.Dtos.Guard;
using ParkGuard.Models;
using TodoApi.Mappers;

namespace ParkGuard.Mappers
{
    public static class GuardMappers
    {
        public static GuardDto ToGuardDto(this Guard guardModel)
        {
            return new GuardDto
            {
                Id = guardModel.Id,
                FirstName = guardModel.FirstName,
                LastName = guardModel.LastName,
                CheckedLocations = guardModel?.CheckedLocations?.Select(c => c.ToLocationDto()).ToList()
            };
        }
        public static Guard ToGuardFromCreateDto(this CreateGuardRequestDto guardDto)
        {
            return new Guard
            {
                FirstName = guardDto.FirstName,
                LastName = guardDto.LastName,
                
            };
        }
    }
}