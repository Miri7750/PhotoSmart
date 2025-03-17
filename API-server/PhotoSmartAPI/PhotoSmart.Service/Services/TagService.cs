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
    public class TagService : ITagService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public TagService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TagDto>> GetAllAsync()
        {
            var tags = await _repositoryManager.Tag.GetAllAsync();
            return _mapper.Map<IEnumerable<TagDto>>(tags);
        }

        public async Task<TagDto> GetByIdAsync(int id)
        {
            var tag = await _repositoryManager.Tag.GetByIdAsync(id);
            return _mapper.Map<TagDto>(tag);
        }

        public async Task<TagDto> CreateAsync(TagDto tagDto)
        {
            var tag = _mapper.Map<Tag>(tagDto);
            var res = await _repositoryManager.Tag.AddAsync(tag);
           return _mapper.Map<TagDto>(res);
        }

        public async Task UpdateAsync(TagDto tagDto)
        {
            var tag = _mapper.Map<Tag>(tagDto);
            await _repositoryManager.Tag.UpdateAsync(tag);
        }

        public async Task DeleteAsync(int id)
        {
            await _repositoryManager.Tag.DeleteAsync(id);
        }
    }
}
