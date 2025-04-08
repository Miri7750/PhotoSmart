using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSmart.Core.IRepositories
{
    public interface IRepositoryManager
    {
        IEventRepository Event { get; }
        IPhotoRepository Photo { get; }
        IUserRepository User { get; }
        IGuestRepository Guest { get; }
        IAuthRepository Auth { get; }

        Task SaveAsync();
    }
}
