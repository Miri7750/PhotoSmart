//using Microsoft.EntityFrameworkCore;//??
using Microsoft.EntityFrameworkCore;
using PhotoSmart.Core.DTOs;
using PhotoSmart.Core.IRepositories;
using PhotoSmart.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSmart.Data.Repositories
{
    public class AlbumRepository : Repository<Album>, IAlbumRepository
    {
        public AlbumRepository(PhotoSmartContext context) : base(context)
        {
        }
        public async Task<Album> GetAlbumIncludePhotosAsync(int albumId)
        {
            return await _dbSet.Include(a => a.Photos).Where(a => a.Id == albumId).FirstOrDefaultAsync();

        }
    }

}
