using System;

namespace TodoApi.Dtos.Account;

public class NewUserDto
{
    public string? Email { get; set; }
    public string? UserName { get; set; }
    public string? Token { get; set; }

}
