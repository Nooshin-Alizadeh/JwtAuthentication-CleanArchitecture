using System;
using System.Collections.Generic;
using System.Text;

namespace JwtAuthentication.Application.DTOs
{
    public record RegisterRequest(string Email, string Password, string FirstName, string LastName);

    public record LoginRequest(string Email, string Password);

    public record AuthResponse(string Token, string Email, string FullName);
    //public record ApplicationUserDto(string Token, Guid Id,string Email, string FullName,string FirstName,string LastName);//todo , need to remove this record and use the AuthResponse record instead
}
