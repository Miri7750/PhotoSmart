using PhotoSmart.Core.IRepositories;
using PhotoSmart.Core.Models;
using PhotoSmart.Data;
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
    }

}
