﻿using HotelLibrary.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary.Repositories
{
    public interface IRoomRepository
    {
        Task<IEnumerable<Room>> GetAllAsync();
        Task<Room> GetByIdAsync(int id);
        Task AddAsync(Room room);
        Task UpdateAsync(Room room);
        Task DeleteAsync(int id);
    }
}