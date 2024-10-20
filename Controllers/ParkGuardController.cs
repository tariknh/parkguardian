using api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkGuard.Dtos.Guard;
using ParkGuard.Mappers;
using ParkGuard.Models;
using TodoApi.Interfaces;

namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ParkGuardController : ControllerBase
{
  
    private readonly ApplicationDBContext _context;
    private readonly IGuardRepository _guardRepo;

    public ParkGuardController(ApplicationDBContext context, IGuardRepository guardRepo)
    {
        _guardRepo = guardRepo;
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(){
        if (!ModelState.IsValid){
                return BadRequest(ModelState);
            }
        var allGuards = await _guardRepo.GetAllAsync();

        var guardDto = allGuards.Select(s=>s.ToGuardDto());

        return Ok(allGuards);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id){
        if (!ModelState.IsValid){
                return BadRequest(ModelState);
            }
        var guard = await _guardRepo.GetByIdAsync(id);
        if(guard == null){
            return NotFound();
        }
        return Ok(guard.ToGuardDto());
    }
    
    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateGuardRequestDto updateDto)
    {
        if (!ModelState.IsValid){
                return BadRequest(ModelState);
            }
        var guardModel = await _guardRepo.UpdateAsync(id, updateDto);
        if(guardModel == null){
            return NotFound();
        }


        return Ok(guardModel.ToGuardDto());
    }

     [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        if (!ModelState.IsValid){
                return BadRequest(ModelState);
            }
        var guardModel = await _guardRepo.DeleteAsync(id);
        if(guardModel == null){
            return NotFound();
        }


        return NoContent();
    }

    [HttpPost] 
    public async Task<IActionResult> Create([FromBody] CreateGuardRequestDto guardDto)
    {
        if (!ModelState.IsValid){
                return BadRequest(ModelState);
            }
        var guardModel = guardDto.ToGuardFromCreateDto();
        await _guardRepo.CreateAsync(guardModel);
        return CreatedAtAction(nameof(GetById), new { id = guardModel.Id }, guardModel.ToGuardDto());  
    }

  
}
