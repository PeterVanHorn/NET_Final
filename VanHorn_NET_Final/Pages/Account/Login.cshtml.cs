//Peter Van Horn
//.NET Final Project
//05/03/2024

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using VanHorn_NET_Final.Models;
using Credential = VanHorn_NET_Final.Models.Credential;

namespace VanHorn_NET_Final.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Credential Credential { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            // verify
            if (Credential.UserName == "teach" && Credential.Password == "password")
            {
                // create security context
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, "teach"),
                    new Claim("Teacher", "True")
                };
                var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);

                return RedirectToPage("/Index");
            }
            if (Credential.UserName == "student" && Credential.Password == "password")
            {
                // create security context
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, "student"),
                    new Claim("Student", "True")
                };
                var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);

                return RedirectToPage("/Index");
            }
            return Page();
        }
    }
}
