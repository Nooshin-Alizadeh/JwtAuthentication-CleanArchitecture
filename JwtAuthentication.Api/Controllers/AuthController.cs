using JwtAuthentication.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using JwtAuthentication.Application.DTOs;
namespace JwtAuthentication.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IIdentityService _identityService;

        public AuthController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var (success, errors) = await _identityService.RegisterAsync(request);
            if (!success)
                return BadRequest(new { Errors = errors });

            return Ok(new { Message = "User registered successfully." });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var (success, response, error) = await _identityService.LoginAsync(request);
            if (!success)
                return Unauthorized(new { Error = error });

            return Ok(response);
        }
    }
}