//using Microsoft.EntityFrameworkCore;//??
using Microsoft.EntityFrameworkCore;
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
    /// <summary>
    /// ///
    /// </summary>
    public class EventRepository : Repository<Event>, IEventRepository
    {
        public EventRepository(PhotoSmartContext context) : base(context)
        {
        }
        public async Task<Event> GetEventIncludePhotosAsync(int eventId)
        {
            return await _dbSet.Include(a => a.Photos).Where(a => a.Id == eventId).FirstOrDefaultAsync();

        }
    }

}
