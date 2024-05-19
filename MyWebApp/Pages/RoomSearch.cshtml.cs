using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HotelWebApp.Pages
{
    public class RoomSearchModel : PageModel
    {
        public string? Beds { get; set; }
        public string? Size { get; set; }

        public void OnGet(string beds, string size)
        {
            Beds = beds;
            Size = size;
        }
    }
}
