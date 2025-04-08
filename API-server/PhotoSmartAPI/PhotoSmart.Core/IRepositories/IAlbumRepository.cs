using PhotoSmart.Core.DTOs;
using PhotoSmart.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSmart.Core.IRepositories
{
    public interface IEventRepository : IRepository<Event>
    {
        Task<Event> GetEventIncludePhotosAsync(int eventId);
        
    }
}
