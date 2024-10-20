using System;
using api.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using ParkGuard.Dtos.Guard;
using ParkGuard.Models;
using TodoApi.Interfaces;

namespace TodoApi.Repository;

public class GuardRepository : IGuardRepository
{
    private readonly ApplicationDBContext _context;
    public GuardRepository (ApplicationDBContext context){
        _context = context;
    }

    public async Task<Guard> CreateAsync(Guard guardModel)
    {
       await _context.Guards.AddAsync(guardModel);
       await _context.SaveChangesAsync();
       return guardModel;
    }

    public async Task<Guard?> DeleteAsync(int id)
    {
        var guardModel = await _context.Guards.FirstOrDefaultAsync(x => x.Id == id);
        if (guardModel == null)
        {
            return null;
        }
        _context.Guards.Remove(guardModel);
        await _context.SaveChangesAsync();
        return guardModel;
    }

    public async Task<List<Guard>> GetAllAsync()
    {
        return await _context.Guards.Include(c=>c.CheckedLocations).ToListAsync();
    }


    public async Task<Guard?> GetByIdAsync(int id)
    {
        return await _context.Guards.Include(c=>c.CheckedLocations).FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task<Guard?> UpdateAsync(int id, UpdateGuardRequestDto guardDto)
    {
        var existingGuard = await _context.Guards.FirstOrDefaultAsync(x => x.Id == id);
        if(existingGuard == null)
        {
            return null;
        }
        existingGuard.FirstName = guardDto.FirstName;
        existingGuard.LastName = guardDto.LastName;
        await _context.SaveChangesAsync();
        
        return existingGuard;
    }

  
}
