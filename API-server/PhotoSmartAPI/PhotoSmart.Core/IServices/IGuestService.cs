﻿using PhotoSmart.Core.DTOs;
using PhotoSmart.Core.IRepositories;
using PhotoSmart.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSmart.Core.IServices
{
    public interface IGuestService: IService<GuestDto>
    {
               Task<IEnumerable<GuestDto>> GetGuestsByEventIdAsync(int eventId);

    }
}
