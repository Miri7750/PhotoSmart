using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1;
using PhotoSmart.Core.DTOs;
using PhotoSmart.Core.IRepositories;
using PhotoSmart.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSmart.Data.Repositories
{
    public class AuthRepository:IAuthRepository
    {
        private readonly DbSet<User> _users;
        public AuthRepository(PhotoSmartContext photoShareContext)
        {
            _users = photoShareContext.Users;
        }

        public async Task<bool> LoginUser(string email, string passwordHash)
        {
            var user = await _users.FirstOrDefaultAsync(u => u.Email == email && u.PasswordHash == passwordHash);
            return user != null;
        }

        public async Task<User> RegisterUser(User newUser)
        {
            var res = await _users.AddAsync(newUser);
            return res.Entity;
        }

    }
}
