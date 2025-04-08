using PhotoSmart.Core.DTOs;
using PhotoSmart.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSmart.Core.IServices
{
    public interface IPhotoService : IService<PhotoDto>
    {
        //Task<IEnumerable<PhotoDto>> GetPhotosByEventId(int eventId);
        Task<IEnumerable<PhotoDto>> GetPhotosByEventIdAsync(int eventId);

        Task UploadPhoto(PhotoDto photoDto);
    }
}
