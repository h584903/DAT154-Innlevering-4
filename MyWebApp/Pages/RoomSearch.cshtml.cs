using Microsoft.AspNetCore.Mvc.RazorPages;
using HotelLibrary.data;
using HotelLibrary.models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelWebApp.Pages
{
    public class RoomSearchModel : PageModel
    {
        private readonly HotellContext _context;

        public RoomSearchModel(HotellContext context)
        {
            _context = context;
        }

        public string? Beds { get; set; }
        public string? Size { get; set; }
        public List<Room> AvailableRooms { get; set; }

        public void OnGet(string beds, string size, string start_date, string stop_date)
        {
            Console.WriteLine(AvailableRooms);
            // Query the database for available rooms based on the search criteria
            AvailableRooms = _context.Rooms
                .Where(r => (r.Beds.ToString() == beds || beds == "*") && (r.Size == size || size == "*"))
                .ToList();

            // Filter the rooms further based on availability between start_date and stop_date
            AvailableRooms = AvailableRooms
                .Where(r => IsRoomAvailable(r.Id, start_date, stop_date))
                .ToList();
        }

        // Method to check room availability for a given date range
        private bool IsRoomAvailable(int roomId, string startDate, string stopDate)
        {
            // Implement logic to check room availability for the given date range
            // For example, query reservations for the room and check if there are any conflicts
            // Return true if the room is available, false otherwise
            return true;
        }
    }
}
