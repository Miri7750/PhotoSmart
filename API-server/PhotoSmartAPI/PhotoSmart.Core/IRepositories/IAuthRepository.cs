using PhotoSmart.Core.Models;


namespace PhotoSmart.Core.IRepositories
{
    public interface IAuthRepository
    {
        Task<User> RegisterUser(User newUser);
        Task<bool> LoginUser(string email, string password);
    }
}
