using api.Dtos.Location;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using TodoApi.Interfaces;
using TodoApi.Mappers;
using ParkGuard.Mappers;
using TodoApi.Helpers;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationRepository _locationRepo;
        public LocationController(ILocationRepository locationRepo)
        {
            _locationRepo = locationRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
        {
            if (!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            var locations = await _locationRepo.GetAllAsync(query);
            if(locations == null){
                return NotFound();
            }
            var locationDto = locations?.Select(s=>s.ToLocationDto());
            return Ok(locationDto);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            var location = await _locationRepo.GetByIdAsync(id);

            if(location == null){
                return NotFound();
            }
            return Ok(location.ToLocationDto());
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateLocationRequestDto locationDtoModel)
        {
            if (!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            var newLocation = locationDtoModel.ToLocationFromCreateDto();
            await _locationRepo.CreateAsync(newLocation);
            return CreatedAtAction(nameof(GetById), new { id = newLocation.Id }, newLocation.ToLocationDto());  
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateLocationDto locationModel){
            if (!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            var location = await _locationRepo.UpdateAsync(locationModel, id);
            if(location == null){
                return NotFound();
            }
            return Ok(location.ToLocationDto());
            
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            var location = await _locationRepo.DeleteAsync(id);
            if(location == null){
                return NotFound("Location does not exist");
            }
           return NoContent();
        }
    }
}
