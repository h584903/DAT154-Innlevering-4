using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HotelLibrary.data;
using HotelLibrary.models;

namespace HotelWebApp.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly HotellContext _context;

        public DeleteModel(HotellContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Reservation Reservation { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Reservation = await _context.Reservations.FindAsync(id);

            if (Reservation == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Reservation == null)
            {
                return NotFound();
            }

            _context.Reservations.Remove(Reservation);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Reservations");
        }
    }
}
