﻿using PhotoSmart.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSmart.Core.IServices
{
    public interface IService<T>where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> CreateAsync(T tag);
        Task UpdateAsync(T tag);
        Task DeleteAsync(int id);

    }
}
