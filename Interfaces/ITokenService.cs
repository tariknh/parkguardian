using System;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

namespace TodoApi.Interfaces;

public interface ITokenService
{
    public string CreateToken(AppUser user);
}
