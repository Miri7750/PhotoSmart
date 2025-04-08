using PhotoSmart.Core.DTOs;

namespace PhotoSmart.Core.IServices
{
    public interface IEventService : IService<EventDto>
    {
        Task<IEnumerable<EventDto>> GetEventsByUserIdAsync(int userId);
    }
}