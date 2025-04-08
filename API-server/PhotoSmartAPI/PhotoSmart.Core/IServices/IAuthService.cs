using PhotoSmart.Core.DTOs;
using PhotoSmart.Core.Models;


namespace PhotoSmart.Core.IServices
{
    public interface IAuthService
    {
        Task<(UserDto,string)?> RegisterAsync(UserDto userDto);
        Task<(UserDto,string)?> LoginAsync(string email, string password);
        string GenerateJwtToken(UserDto user, ICollection<Role> roles);
    }
}
