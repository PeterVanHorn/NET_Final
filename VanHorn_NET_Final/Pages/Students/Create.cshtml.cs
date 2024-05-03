//Peter Van Horn
//.NET Final Project
//05/03/2024

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using VanHorn_NET_Final.Models;

namespace VanHorn_NET_Final.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly VanHorn_NET_Final.Models.DomainContext _context;

        public CreateModel(VanHorn_NET_Final.Models.DomainContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherId");
            return Page();
        }

        [BindProperty]
        public Student Student { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            _context.Students.Add(Student);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
