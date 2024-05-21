using HotelLibrary.models;
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
        System.Threading.Tasks.Task AddAsync(Room room);
        System.Threading.Tasks.Task UpdateAsync(Room room);
        System.Threading.Tasks.Task DeleteAsync(int id);
        System.Threading.Tasks.Task MarkAsNeedsCleaningAsync(int roomId);
        System.Threading.Tasks.Task MarkAsNeedsMaintenanceAsync(int roomId);
        System.Threading.Tasks.Task MarkAsCleanedAsync(int roomId);
        System.Threading.Tasks.Task MarkAsMaintainedAsync(int roomId);
        System.Threading.Tasks.Task MarkAsNeedsRoomServiceAsync(int roomId);
        bool IsRoomAvailable(int roomId, DateTime date);
    }
}
