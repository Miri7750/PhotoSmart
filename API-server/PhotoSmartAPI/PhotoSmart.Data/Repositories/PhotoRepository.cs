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
    public class PhotoRepository : Repository<Photo>, IPhotoRepository
    {
        public PhotoRepository(PhotoSmartContext context) : base(context)
        {

        }
      
    }

}
