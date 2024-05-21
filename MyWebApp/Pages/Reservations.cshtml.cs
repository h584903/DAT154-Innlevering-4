using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HotelLibrary.data;
using HotelLibrary.models;
using Microsoft.AspNetCore.Authorization;

namespace HotelWebApp.Pages
{
    [Authorize]
    public class ReservationsModel : PageModel
    {
        private readonly HotellContext _context;

        public ReservationsModel(HotellContext context)
        {
            _context = context;
        }

        public IList<Reservation> Reservation { get; set; } = default!;

        public async System.Threading.Tasks.Task OnGetAsync()
        {
            var username = User.Identity.Name;
            Reservation = await _context.Reservations
                .Where(r => r.CustomerName == username)
                .Include(r => r.Room)
                .ToListAsync();
        }
    }
}
