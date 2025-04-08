using PhotoSmart.Core.IRepositories;
using PhotoSmart.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSmart.Data.Repositories
{
    /// <summary>
    /// ///
    /// </summary>
    public class GuestRepository : Repository<Guest>, IGuestRepository
    {
        public GuestRepository(PhotoSmartContext context) : base(context)
        {

        }
    }

}
