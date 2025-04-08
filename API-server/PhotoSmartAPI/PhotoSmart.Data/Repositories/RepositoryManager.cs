using PhotoSmart.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSmart.Data.Repositories
{
    /// <summary>
    /// ///
    /// </summary>
    public class RepositoryManager : IRepositoryManager
    {
        PhotoSmartContext _photoShareContext;

        public IEventRepository Event { get; }

        public IPhotoRepository Photo { get; }

        public IUserRepository User { get; }

        public IGuestRepository Guest { get; }

        public IAuthRepository Auth { get; }

        public RepositoryManager(PhotoSmartContext photoShareContext, IEventRepository eventRepository, IPhotoRepository photo, IUserRepository user, IGuestRepository guest, IAuthRepository auth)
        {
            _photoShareContext = photoShareContext;
            Event = eventRepository;
            Photo = photo;
            User = user;
            Guest = guest;
            Auth = auth;
        }
        public async Task SaveAsync()
        {
            await _photoShareContext.SaveChangesAsync();
        }
    }
}
