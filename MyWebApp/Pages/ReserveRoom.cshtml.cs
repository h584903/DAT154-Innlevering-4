using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HotelLibrary.data;
using HotelLibrary.models;
using System;
using System.Threading.Tasks;

namespace HotelWebApp.Pages
{
    public class ReserveRoomModel : PageModel
    {
        private readonly HotellContext _context;

        public ReserveRoomModel(HotellContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Reservation Reservation { get; set; }

        public async Task<IActionResult> OnGetAsync(int id, string start_date, string stop_date)
        {
            DateTime checkInDate = DateTime.Parse(start_date + " 12:00:00");
            DateTime checkOutDate = DateTime.Parse(stop_date + " 11:00:00");

            Reservation = new Reservation
            {
                RoomId = id,
                CheckInDate = checkInDate,
                CheckOutDate = checkOutDate,
                CustomerName = User.Identity.Name,
                IsCheckedIn = false
            };

            _context.Reservations.Add(Reservation);

            await _context.SaveChangesAsync();

            return RedirectToPage("./Reservations");
        }
    }
}
