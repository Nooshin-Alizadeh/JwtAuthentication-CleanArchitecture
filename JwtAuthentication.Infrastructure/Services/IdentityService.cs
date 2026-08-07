using JwtAuthentication.Application.DTOs;
using JwtAuthentication.Application.Interfaces;
using JwtAuthentication.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace JwtAuthentication.Infrastructure.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public IdentityService(UserManager<ApplicationUser> userManager, IJwtTokenGenerator jwtTokenGenerator)
        {
            _userManager = userManager;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<(bool Success, string[] Errors)> RegisterAsync(RegisterRequest request)
        {
            var existingUser = await _userManager.FindByEmailAsync(request.Email);
            if (existingUser != null)
                return (false, new[] { "User with this email already exists." });

            var user = ApplicationUser.Create(request.Email, request.FirstName, request.LastName);
            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
                return (false, result.Errors.Select(e => e.Description).ToArray());

            return (true, Array.Empty<string>());
        }

        public async Task<(bool Success, AuthResponse? Response, string Error)> LoginAsync(LoginRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
                return (false, null, "Invalid credentials.");

            var isValidPassword = await _userManager.CheckPasswordAsync(user, request.Password);
            if (!isValidPassword)
                return (false, null, "Invalid credentials.");

            var token = _jwtTokenGenerator.GenerateToken(user);
            var response = new AuthResponse(token, user.Email!, $"{user.FirstName} {user.LastName}");

            return (true, response, string.Empty);
        }
    }
}
