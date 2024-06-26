using Microsoft.AspNetCore.Mvc.RazorPages;
using HotelLibrary.data;
using HotelLibrary.models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using HotelLibrary.Repositories;

namespace HotelWebApp.Pages
{
    public class RoomSearchModel : PageModel
    {
        private readonly HotellContext _context;
        private readonly IRoomRepository roomRepository;

        public RoomSearchModel(HotellContext context, IRoomRepository roomRepository)
        {
            _context = context;
            this.roomRepository = roomRepository;
        }


        public string Beds { get; set; }
        public string Size { get; set; }
        public List<Room> AvailableRooms { get; set; }
        public List<Reservation> reservationList;

        public async Task OnGetAsync(string beds, string size, string start_date, string stop_date)
        {
            

            AvailableRooms = await _context.Rooms
                .Where(r => (r.Beds.ToString() == beds || beds == "*") && (r.Size == size || size == "*"))
                .ToListAsync();

            reservationList = await _context.Reservations
                .ToListAsync();

            AvailableRooms = AvailableRooms.Where(r => roomRepository.IsRoomAvailablePeriod(r.Id, DateTime.Parse(start_date + " 12:00:00"), DateTime.Parse(stop_date + " 11:00:00"))).ToList();

            AvailableRooms = AvailableRooms
                .GroupBy(r => r.Name)
                .Select(group => group.First())
                .ToList();
        }

        
    }
}
