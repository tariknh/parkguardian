using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Dtos.Account;
using TodoApi.Interfaces;
using TodoApi.Mappers;
using TodoApi.Models;

namespace TodoApi.Controllers;
[Route("api/account")]
[ApiController]
public class AccountController : ControllerBase
{
private readonly UserManager<AppUser> _userManager;
private readonly ITokenService _tokenService;
public AccountController(UserManager<AppUser> userManager, ITokenService tokenService)
{
    _userManager = userManager;
    _tokenService = tokenService;
}
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        try
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var appUser = new AppUser
            {
                UserName = registerDto.Username,
                Email = registerDto.Email
            };
            var createdUser = await _userManager.CreateAsync(appUser, registerDto.Password);

            if(createdUser.Succeeded)
            {
                var roleResult = await _userManager.AddToRoleAsync(appUser, "User");
                if(roleResult.Succeeded)
                {
                    return Ok(
                        new NewUserDto{
                            Username = appUser.UserName,
                            Email = appUser.Email,
                            Token = _tokenService.CreateToken(appUser)
                        }
                    );
                }else
                {
                    return StatusCode(500, roleResult.Errors);
                }
            }
            else
            {
                return StatusCode(500, createdUser.Errors);
            }
        }
        catch (Exception e)
        {
            return StatusCode(500, e);
        }
    }
}
