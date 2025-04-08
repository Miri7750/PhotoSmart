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
    [Route("api/guests")]
    public class GuestController : ControllerBase
    {
        private readonly IGuestService _guestService;
        private readonly IMapper _mapper;

        public GuestController(IGuestService guestService, IMapper mapper)
        {
            _guestService = guestService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateGuest([FromBody] GuestPostModel guestPostModel)
        {
            var guestDto = _mapper.Map<GuestDto>(guestPostModel);
            var createdGuest = await _guestService.CreateAsync(guestDto);
            return CreatedAtAction(nameof(GetGuestById), new { id = createdGuest.Id }, createdGuest);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGuests()
        {
            var guests = await _guestService.GetAllAsync();
            return Ok(guests);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGuestById(int id)
        {
            var guest = await _guestService.GetByIdAsync(id);
            if (guest == null)
            {
                return NotFound();
            }
            return Ok(guest);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGuest(int id)
        {
            await _guestService.DeleteAsync(id);
            return NoContent();
        }
    }
}
