using System;
using api.Dtos.Location;
using ParkGuard.Models;
using TodoApi.Helpers;

namespace TodoApi.Interfaces;

public interface ILocationRepository
{
    Task <List<Location>?> GetAllAsync(QueryObject query);
    Task <Location?> GetByIdAsync(int id);
    Task <Location?> CreateAsync(Location locationModel);
    Task <Location?> UpdateAsync(UpdateLocationDto UpdateLocationDto, int id);
    Task <Location?> DeleteAsync(int id);

}
