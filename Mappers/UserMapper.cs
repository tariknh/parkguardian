using System;
using TodoApi.Dtos.Account;
using TodoApi.Models;

namespace TodoApi.Mappers;

public static class UserMappers
{
    public static NewUserDto ToNewUserDto(this AppUser user){
        return new NewUserDto{
            Email = user.Email,
            Username = user.UserName,
        };
    }
}


