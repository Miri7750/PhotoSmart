//using Microsoft.EntityFrameworkCore;//??
using PhotoSmart.Core.IRepositories;
using PhotoSmart.Core.Models;
using PhotoSmart.Data;
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
    }

}
