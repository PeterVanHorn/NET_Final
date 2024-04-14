using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using VanHorn_NET_Final.Models;

namespace VanHorn_NET_Final.Pages.Options
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
            ViewData["QuestionId"] = new SelectList(_context.Questions, "QuestionId", "QuestionText");
            return Page();
        }

        [BindProperty]
        public Option Option { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            _context.Options.Add(Option);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Quizzes/Index");
        }
    }
}
