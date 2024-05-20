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

        public Task AddRoomAsync(Room room)
        {
            return _roomRepository.AddAsync(room);
        }

        public Task UpdateRoomAsync(Room room)
        {
            return _roomRepository.UpdateAsync(room);
        }

        public Task DeleteRoomAsync(int id)
        {
            return _roomRepository.DeleteAsync(id);
        }

        public Task MarkRoomAsNeedsCleaningAsync(int roomId)
        {
            return _roomRepository.MarkAsNeedsCleaningAsync(roomId);
        }

        public Task MarkRoomAsNeedsMaintenanceAsync(int roomId)
        {
            return _roomRepository.MarkAsNeedsMaintenanceAsync(roomId);
        }

        public Task MarkRoomAsCleanedAsync(int roomId)
        {
            return _roomRepository.MarkAsCleanedAsync(roomId);
        }

        public Task MarkRoomAsMaintainedAsync(int roomId)
        {
            return _roomRepository.MarkAsMaintainedAsync(roomId);
        }

        public Task MarkRoomAsNeedsRoomServiceAsync(int roomId)
        {
            return _roomRepository.MarkAsNeedsRoomServiceAsync(roomId);
        }

    }
}