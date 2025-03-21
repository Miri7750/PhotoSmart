﻿using AutoMapper;
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
    public class AlbumService : IAlbumService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public AlbumService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<AlbumDto> CreateAlbum(AlbumDto albumDto)
        {
            var album = _mapper.Map<Album>(albumDto);
           var res= await _repositoryManager.Album.AddAsync(album);
            return _mapper.Map<AlbumDto>(res);
        }

        public async Task<IEnumerable<AlbumDto>> GetAllAlbums()
        {
            var albums = await _repositoryManager.Album.GetAllAsync();
            return albums.Select(a => new AlbumDto
            {
                Id = a.Id,
                Title = a.Title,
                Description = a.Description
            });
        }
        public async Task<IEnumerable<AlbumDto>> GetAllAsync()
        {
            var albums = await _repositoryManager.Album.GetAllAsync();
            return _mapper.Map<IEnumerable<AlbumDto>>(albums);
        }

        public async Task<AlbumDto> GetByIdAsync(int id)
        {
            var album = await _repositoryManager.Album.GetByIdAsync(id);
            return _mapper.Map<AlbumDto>(album);
        }

        public async Task<AlbumDto> CreateAsync(AlbumDto albumDto)
        {
            var album = _mapper.Map<Album>(albumDto);
           var res= await _repositoryManager.Album.AddAsync(album);
            return _mapper.Map<AlbumDto>(res);
        }

        public async Task UpdateAsync(AlbumDto albumDto)
        {
            var album = _mapper.Map<Album>(albumDto);
            await _repositoryManager.Album.UpdateAsync(album);
        }

        public async Task DeleteAsync(int id)
        {
            await _repositoryManager.Album.DeleteAsync(id);
        }

    }

}
