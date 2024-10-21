using System;
using api.Data;
using api.Dtos.Location;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using ParkGuard.Models;
using TodoApi.Helpers;
using TodoApi.Interfaces;

namespace api.Repository;

public class LocationRepository : ILocationRepository
{
    private readonly ApplicationDBContext _context;

    public LocationRepository(ApplicationDBContext context){
        _context = context;

    }

    public async Task<Location?> CreateAsync(Location location)
    {
        await _context.Locations.AddAsync(location);
        await _context.SaveChangesAsync();
        return location;
    }



    public async Task<List<Location>?> GetAllAsync(QueryObject query)
    {
        var locations =  _context.Locations.AsQueryable();
        if(!string.IsNullOrWhiteSpace(query.City)){
            locations = locations.Where(x => x.City.Contains(query.City));
        }
         if(!string.IsNullOrWhiteSpace(query.Street)){
            locations = locations.Where(x => x.Street.Contains(query.Street));
        }
        if(!locations.Any()){
            return null;
        }
        if(!string.IsNullOrWhiteSpace(query.SortBy))
        {
            if(query.SortBy.Equals("City", StringComparison.OrdinalIgnoreCase)){
                locations = query.IsDescending ? locations.OrderByDescending(s=>s.City) : locations.OrderBy(s=>s.City);
            }
            if(query.SortBy.Equals("Date", StringComparison.OrdinalIgnoreCase)){
                locations = query.IsDescending ? locations.OrderByDescending(s=>s.LastCheck) : locations.OrderBy(s=>s.LastCheck);
            }
        }
        var skipNumber = (query.PageNumber - 1) * query.PageSize;


        return await locations.Skip(skipNumber).Take(query.PageSize).ToListAsync();
    }

    

    public async Task<Location?> UpdateAsync(UpdateLocationDto UpdateLocationDto, int id){
        var location = await _context.Locations.FirstOrDefaultAsync(x=>x.Id == id);
        if(location == null){
            return null;
        }
        if(UpdateLocationDto.City != null) location.City = UpdateLocationDto.City;
        if(UpdateLocationDto.Street != null) location.Street = UpdateLocationDto.Street;
        if(UpdateLocationDto.GuardId != null) location.GuardId = UpdateLocationDto.GuardId;
        if(UpdateLocationDto.LastCheck.HasValue) location.LastCheck = UpdateLocationDto.LastCheck.Value;
        await _context.SaveChangesAsync();
        return location;
    }

  

    public async Task<Location?> GetByIdAsync(int id)
    {
        return await _context.Locations.FindAsync(id);
    }

    public async Task<Location?> DeleteAsync(int id)
    {
        var location = await _context.Locations.FindAsync(id);

        if(location == null){
            return null;
        }
        _context.Locations.Remove(location);
        await _context.SaveChangesAsync();
        return location;
    }
}
