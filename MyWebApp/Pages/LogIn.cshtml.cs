using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace HotelWebApp.Pages
{
    public class LoginModel : PageModel
    {
        private static readonly Dictionary<string, string> users = new()
        {
            { "Petter", "passord" },
            { "Kristoffer", "passord" }
        };

        [BindProperty]
        public required string Username { get; set; }
        [BindProperty]
        public required string Password { get; set; }
        public string? ErrorMessage { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (users.TryGetValue(Username, out var password) && password == Password)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, Username)
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity), authProperties);

                return RedirectToPage("/Index");
            }
            else
            {
                ErrorMessage = "Invalid login attempt.";
                return Page();
            }
        }
    }
}
