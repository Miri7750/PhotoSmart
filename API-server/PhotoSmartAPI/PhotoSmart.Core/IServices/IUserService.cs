using PhotoSmart.Core.DTOs;
using PhotoSmart.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSmart.Core.IServices
{
    public interface IUserService:IService<UserDto>
    {
         Task<UserDto> GetUserByEmailAsync(string email);
        Task UpdateUserRoleAsync(int userId, string role);
    }
}
