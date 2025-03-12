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
    public class PhotoService:IPhotoService
    {
        private readonly IPhotoRepository _photoRepository;

        public PhotoService(IPhotoRepository photoRepository)
        {
            _photoRepository = photoRepository;
        }

        public async Task<PhotoDto> UploadPhoto(PhotoDto photoDto)
        {
            var photo = new Photo
            {
                Url = photoDto.Url,
                UploadedAt = DateTime.Now
            };
            await _photoRepository.AddAsync(photo);
            return photoDto; // החזרת ה-DTO שנוצר
        }

        public async Task<IEnumerable<PhotoDto>> GetPhotosByAlbumId(int albumId)
        {
            var photos = await _photoRepository.GetAllAsync();
            return photos.Where(p => p.Albums.Any(a => a.Id == albumId)).Select(p => new PhotoDto
            {
                Id = p.Id,
                Url = p.Url
            });
        }

        public async Task<IEnumerable<Photo>> GetAllAsync()
        {
            return await _photoRepository.GetAllAsync();
        }

        public async Task<Photo> GetByIdAsync(int id)
        {
            return await _photoRepository.GetByIdAsync(id);
        }

        public async Task CreateAsync(Photo photo)
        {
            await _photoRepository.AddAsync(photo);
        }

        public async Task UpdateAsync(Photo photo)
        {
            await _photoRepository.UpdateAsync(photo);
        }

        public async Task DeleteAsync(int id)
        {
            await _photoRepository.DeleteAsync(id);
        }

    }

}
