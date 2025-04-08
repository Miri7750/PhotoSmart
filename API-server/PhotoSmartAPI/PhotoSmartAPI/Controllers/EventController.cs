using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhotoSmart.Api.PostModels;
using PhotoSmart.Core.DTOs;
using PhotoSmart.Core.IServices;
using PhotoSmart.Service.Services;

namespace PhotoSmart.Api.Controllers
{
    [ApiController]
    [Route("api/events")]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;
        private readonly IMapper _mapper;

        public EventController(IEventService eventService,IMapper mapper)
        {
            _eventService = eventService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent([FromBody] EventPostModel eventPostModel)
        {
            var eventDto = _mapper.Map<EventDto>(eventPostModel);
            var createdEvent = await _eventService.CreateAsync(eventDto);
            return CreatedAtAction(nameof(GetEventById), new { id = createdEvent.Id }, createdEvent);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEvents()
        {
            var events = await _eventService.GetAllAsync();
            return Ok(events);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventById(int id)
        {
            var resEvent = await _eventService.GetByIdAsync(id);
            if (resEvent == null)
            {
                return NotFound();
            }
            return Ok(resEvent);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            await _eventService.DeleteAsync(id);
            return NoContent();
        }
    }

}
