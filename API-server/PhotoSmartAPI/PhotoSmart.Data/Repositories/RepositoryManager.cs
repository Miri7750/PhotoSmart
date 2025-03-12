using PhotoSmart.Core.IRepositories;
using PhotoSmart.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSmart.Data.Repositories
{
    internal class RepositoryManager : IRepositoryManager
    {
        PhotoSmartContext _PhotoSmartContext;

        public IAlbumRepository Album {  get; }

        public IPhotoRepository Photo {  get; }

        public IUserRepository User {  get; }

        public ITagRepository Tag {  get; }

        RepositoryManager(PhotoSmartContext PhotoSmartContext, IAlbumRepository album, IPhotoRepository photo, IUserRepository user, ITagRepository tag)
        {
            _PhotoSmartContext = PhotoSmartContext;
            Album = album;
            Photo = photo;
            User = user;
            Tag = tag;
        }
        public async Task SaveAsync()
        {
            await _PhotoSmartContext.SaveChangesAsync();
        }
    }
}
