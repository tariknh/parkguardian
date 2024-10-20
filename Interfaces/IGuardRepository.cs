using System;
using ParkGuard.Dtos.Guard;
using ParkGuard.Models;

namespace TodoApi.Interfaces;

public interface IGuardRepository
{
    Task<List<Guard>> GetAllAsync();
    Task<Guard?> GetByIdAsync(int id);
    Task<Guard> CreateAsync(Guard guardModel);
    Task<Guard?> UpdateAsync(int id, UpdateGuardRequestDto guardDto);
    Task<Guard?> DeleteAsync(int id);

}
