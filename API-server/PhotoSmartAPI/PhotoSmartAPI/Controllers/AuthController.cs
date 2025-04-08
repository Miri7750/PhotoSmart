using Microsoft.AspNetCore.Mvc;
using PhotoSmart.Core.DTOs;
using PhotoSmart.Core.IServices;
using System;
using System.Threading.Tasks;
using PhotoSmart.Api.PostModels;
using AutoMapper;

namespace PhotoSmart.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public AuthController(IAuthService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterPostModel userRegisterPost)
        {
            if (userRegisterPost == null)
            {
                return BadRequest("User registration data is required.");
            }
            try
            {
                var userDto = _mapper.Map<UserDto>(userRegisterPost);
                var createdUser = await _authService.RegisterAsync(userDto);
                if (createdUser == null)
                {
                    return Conflict("This email already exists in the system.");
                }
                Console.WriteLine(createdUser);
                return Ok(new { createdUser.Value.Item1, createdUser.Value.Item2 });
            }
            catch (Exception ex)
            {
                // Log the exception (not shown here for brevity)
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginPostModel userLogin)
        {
            try
            {
                var user = await _authService.LoginAsync(userLogin.Email, userLogin.Password);
                if (user == null)
                {
                    return Unauthorized();
                }

                return Ok(user);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
            catch (Exception ex)
            {
                // Log the exception (not shown here for brevity)
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
