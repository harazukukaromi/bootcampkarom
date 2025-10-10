using JwtAuthApi.Models;
using JwtAuthApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly JwtService _jwtService;

        public AuthController(JwtService jwtService)
        {
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserModel user)
        {
            // simulasi user valid
            if (user.Username == "admin" && user.Password == "123")
            {
                var token = _jwtService.GenerateToken(user.Username);
                return Ok(new { token });
            }

            return Unauthorized();
        }
    }
}