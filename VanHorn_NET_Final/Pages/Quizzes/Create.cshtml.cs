//Peter Van Horn
//.NET Final Project
//05/03/2024

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using VanHorn_NET_Final.Models;


namespace VanHorn_NET_Final.Pages.Quizzes
{
    [Authorize(Policy = "TeacherOnly")]
    public class CreateModel : PageModel
    {
        private readonly VanHorn_NET_Final.Models.DomainContext _context;

        public CreateModel(VanHorn_NET_Final.Models.DomainContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "LastName");
            return Page();
        }

        [BindProperty]
        public Quiz Quiz { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            _context.Quizzes.Add(Quiz);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Questions/Create", new { quizId = Quiz.QuizId});
        }
    }
}
