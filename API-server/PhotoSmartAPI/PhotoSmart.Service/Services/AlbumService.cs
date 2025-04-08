using AutoMapper;
using PhotoSmart.Core.DTOs;
using PhotoSmart.Core.IRepositories;
using PhotoSmart.Core.IServices;
using PhotoSmart.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSmart.Service.Services
{
    public class EventService : IEventService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public EventService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<EventDto> CreateEvent(EventDto eventDto)
        {
            var newEvent = _mapper.Map<Event>(eventDto);
           var res= await _repositoryManager.Event.AddAsync(newEvent);
            return _mapper.Map<EventDto>(res);
        }

        public async Task<IEnumerable<EventDto>> GetAllEvents()
        {
            var events = await _repositoryManager.Event.GetAllAsync();
            return events.Select(a => new EventDto
            {
                Id = a.Id,
                Title = a.Title,
                Description = a.Description
            });
        }
        public async Task<IEnumerable<EventDto>> GetAllAsync()
        {
            var events = await _repositoryManager.Event.GetAllAsync();
            return _mapper.Map<IEnumerable<EventDto>>(events);
        }

        public async Task<EventDto> GetByIdAsync(int id)
        {
            var eventRes = await _repositoryManager.Event.GetByIdAsync(id);
            return _mapper.Map<EventDto>(eventRes);
        }

        public async Task<EventDto> CreateAsync(EventDto eventDto)
        {
            var newEvent = _mapper.Map<Event>(eventDto);
           var res= await _repositoryManager.Event.AddAsync(newEvent);
            return _mapper.Map<EventDto>(res);
        }

        public async Task UpdateAsync(EventDto eventDto)
        {
            var newEvent = _mapper.Map<Event>(eventDto);
            await _repositoryManager.Event.UpdateAsync(newEvent);
        }

        public async Task DeleteAsync(int id)
        {
            await _repositoryManager.Event.DeleteAsync(id);
        }

        public Task<IEnumerable<EventDto>> GetEventsByUserIdAsync(int userId)
        {
            throw new NotImplementedException();
        }
    }

}
