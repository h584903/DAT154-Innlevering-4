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
            // Convert string dates to DateTime
            DateTime checkInDate = DateTime.Parse(start_date + " 12:00:00");
            DateTime checkOutDate = DateTime.Parse(stop_date + " 11:00:00");

            // Create a new reservation
            Reservation = new Reservation
            {
                RoomId = id,
                CheckInDate = checkInDate,
                CheckOutDate = checkOutDate,
                CustomerName = "John Doe", // This should be replaced with actual customer data
                IsCheckedIn = false
            };

            // Add the reservation to the context
            _context.Reservations.Add(Reservation);

            // Save the changes to the database
            await _context.SaveChangesAsync();

            // Redirect to a confirmation page or another appropriate page
            return RedirectToPage("./Reservations");
        }
    }
}
