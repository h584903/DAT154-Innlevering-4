using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HotelLibrary.data;
using HotelLibrary.models;

namespace HotelWebApp.Pages
{
    public class ReservationsModel : PageModel
    {
        private readonly HotelLibrary.data.HotellContext _context;

        public ReservationsModel(HotelLibrary.data.HotellContext context)
        {
            _context = context;
        }

        public IList<Reservation> Reservation { get;set; } = default!;

        public async System.Threading.Tasks.Task OnGetAsync()
        {
            Reservation = await _context.Reservations
                .Include(r => r.Room).ToListAsync();
        }
    }
}
