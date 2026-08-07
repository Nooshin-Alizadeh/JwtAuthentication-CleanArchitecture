using JwtAuthentication.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace JwtAuthentication.Application.Interfaces
{
    public interface IIdentityService
    {
        Task<(bool Success, string[] Errors)> RegisterAsync(RegisterRequest request);
        Task<(bool Success, AuthResponse? Response, string Error)> LoginAsync(LoginRequest request);
    }
}
