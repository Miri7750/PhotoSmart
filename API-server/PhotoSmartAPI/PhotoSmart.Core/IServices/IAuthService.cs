using PhotoSmart.Core.DTOs;
using PhotoSmart.Core.Models;


namespace PhotoSmart.Core.IServices
{
    public interface IAuthService
    {
        Task<UserDto> RegisterUser(UserDto userDto);
        Task<string> LoginUser(string email, string password);
        string GenerateJwtToken(UserDto user, string[] roles);
    }
}
