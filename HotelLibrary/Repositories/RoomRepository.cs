using HotelLibrary.data;
using HotelLibrary.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly HotellContext _context;

        public RoomRepository(HotellContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Room>> GetAllAsync()
        {
            return await _context.Rooms.ToListAsync();
        }

        public async Task<Room> GetByIdAsync(int id)
        {
            return await _context.Rooms.FindAsync(id);
        }

        public async Task AddAsync(Room room)
        {
            await _context.Rooms.AddAsync(room);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Room room)
        {
            _context.Rooms.Update(room);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var room = await _context.Rooms.FindAsync(id);
            if (room != null)
            {
                _context.Rooms.Remove(room);
                await _context.SaveChangesAsync();
            }
        }
        public async Task MarkAsNeedsCleaningAsync(int roomId)
        {
            var room = await _context.Rooms.FindAsync(roomId);
            if (room != null)
            {
                room.NeedsCleaning = true;
                room.IsAvailable = false;
                await _context.SaveChangesAsync();
            }
        }

        public async Task MarkAsNeedsMaintenanceAsync(int roomId)
        {
            var room = await _context.Rooms.FindAsync(roomId);
            if (room != null)
            {
                room.NeedsMaintenance = true;
                room.IsAvailable = false;
                await _context.SaveChangesAsync();
            }
        }

        public async Task MarkAsCleanedAsync(int roomId)
        {
            var room = await _context.Rooms.FindAsync(roomId);
            if (room != null)
            {
                room.NeedsCleaning = false;
                room.IsAvailable = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task MarkAsMaintainedAsync(int roomId)
        {
            var room = await _context.Rooms.FindAsync(roomId);
            if (room != null)
            {
                room.NeedsMaintenance = false;
                room.IsAvailable = true;
                await _context.SaveChangesAsync();
            }
        }
        public async Task MarkAsNeedsRoomServiceAsync(int roomId)
        {
            var room = await _context.Rooms.FindAsync(roomId);
            if (room != null)
            {
                room.NeedsRoomService = true;
                await _context.SaveChangesAsync();
            }
        }
    }
}
