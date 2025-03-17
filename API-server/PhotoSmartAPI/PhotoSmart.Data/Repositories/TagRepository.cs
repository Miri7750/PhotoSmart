using PhotoSmart.Core.IRepositories;
using PhotoSmart.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSmart.Data.Repositories
{
    public class TagRepository : Repository<Tag>, ITagRepository
    {
        public TagRepository(PhotoSmartContext context) : base(context)
        {

        }
    }

}
