using JwtAuthentication.Application.DTOs;
using JwtAuthentication.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace JwtAuthentication.Application.Interfaces
{
    public interface IJwtTokenGenerator
    {
        //string GenerateToken(ApplicationUserDto user);
        string GenerateToken(ApplicationUser user);//Todo Add Project Reference to JwtAuthentication.Infrastructure.Identity project to use the ApplicationUser class
    }
}
