using Microsoft.EntityFrameworkCore;
using PhotoSmart.Core.IRepositories;
using PhotoSmart.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSmart.Data.Repositories
{
    public class UserRepository : Repository<User> ,IUserRepository
    {
        public UserRepository(PhotoSmartContext context) : base(context)
        {
        }

        public async Task<User> GetByUserEmailAsync(string userEmail)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Email == userEmail);
        }
    }

}
