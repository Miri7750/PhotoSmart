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
    public class GuestService : IGuestService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public GuestService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GuestDto>> GetAllAsync()
        {
            var guests = await _repositoryManager.Guest.GetAllAsync();
            return _mapper.Map<IEnumerable<GuestDto>>(guests);
        }

        public async Task<GuestDto> GetByIdAsync(int id)
        {
            var guest = await _repositoryManager.Guest.GetByIdAsync(id);
            return _mapper.Map<GuestDto>(guest);
        }

        public async Task<GuestDto> CreateAsync(GuestDto guestDto)
        {
            var guest = _mapper.Map<Guest>(guestDto);
            var res = await _repositoryManager.Guest.AddAsync(guest);
           return _mapper.Map<GuestDto>(res);
        }

        public async Task UpdateAsync(GuestDto guestDto)
        {
            var guest = _mapper.Map<Guest>(guestDto);
            await _repositoryManager.Guest.UpdateAsync(guest);
        }

        public async Task DeleteAsync(int id)
        {
            await _repositoryManager.Guest.DeleteAsync(id);
        }

        public Task<IEnumerable<GuestDto>> GetGuestsByEventIdAsync(int eventId)
        {
            throw new NotImplementedException();
        }
    }
}
