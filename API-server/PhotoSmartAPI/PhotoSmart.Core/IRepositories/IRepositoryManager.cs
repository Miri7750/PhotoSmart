﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSmart.Core.IRepositories
{
    public interface IRepositoryManager
    {
        IAlbumRepository Album { get; }
        IPhotoRepository Photo { get; }
        IUserRepository User { get; }
        ITagRepository Tag { get; }
        Task SaveAsync();
    }
}
