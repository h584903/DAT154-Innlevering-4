using HotelLibrary.models;
using HotelLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary.services
{
    public class RoomService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public Task<IEnumerable<Room>> GetAllRoomsAsync()
        {
            return _roomRepository.GetAllAsync();
        }

        public Task<Room> GetRoomByIdAsync(int id)
        {
            return _roomRepository.GetByIdAsync(id);
        }

        public System.Threading.Tasks.Task AddRoomAsync(Room room)
        {
            return _roomRepository.AddAsync(room);
        }

        public System.Threading.Tasks.Task UpdateRoomAsync(Room room)
        {
            return _roomRepository.UpdateAsync(room);
        }

        public System.Threading.Tasks.Task DeleteRoomAsync(int id)
        {
            return _roomRepository.DeleteAsync(id);
        }

        public System.Threading.Tasks.Task MarkRoomAsNeedsCleaningAsync(int roomId)
        {
            return _roomRepository.MarkAsNeedsCleaningAsync(roomId);
        }

        public System.Threading.Tasks.Task MarkRoomAsNeedsMaintenanceAsync(int roomId)
        {
            return _roomRepository.MarkAsNeedsMaintenanceAsync(roomId);
        }

        public System.Threading.Tasks.Task MarkRoomAsCleanedAsync(int roomId)
        {
            return _roomRepository.MarkAsCleanedAsync(roomId);
        }

        public System.Threading.Tasks.Task MarkRoomAsMaintainedAsync(int roomId)
        {
            return _roomRepository.MarkAsMaintainedAsync(roomId);
        }

        public System.Threading.Tasks.Task MarkRoomAsNeedsRoomServiceAsync(int roomId)
        {
            return _roomRepository.MarkAsNeedsRoomServiceAsync(roomId);
        }

    }
}