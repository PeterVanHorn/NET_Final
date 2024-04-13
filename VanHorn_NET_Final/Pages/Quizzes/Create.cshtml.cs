using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using VanHorn_NET_Final.Models;

// maybe consider adding questions in the quiz editing section?

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
        public Question Question { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        //public async Task<IActionResult> OnPostAsync()
        //{
        //    //if (!ModelState.IsValid)
        //    //{
        //    //    return Page();
        //    //}

        //    _context.Quizzes.Add(Quiz);
        //    await _context.SaveChangesAsync();

        //    return RedirectToPage("./Index");
        //}

        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}
            Quiz.Questions.Add(Question);
            _context.Questions.Add(Question);
            _context.Quizzes.Add(Quiz);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        // POST: Quiz/CreateWithQuestion
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult CreateWithQuestion(QuizWithQuestion qwq)
        //{
        //    _context.Add(qwq.Question);
        //    qwq.Quiz.Questions.Add(qwq.Question);
        //    _context.Add(qwq.Quiz);
        //    return RedirectToAction(nameof(Index));
        //}
    }
}
