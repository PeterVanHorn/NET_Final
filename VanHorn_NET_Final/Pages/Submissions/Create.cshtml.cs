using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VanHorn_NET_Final.Models;

namespace VanHorn_NET_Final.Pages.Submissions
{
    public class CreateModel : PageModel
    {
        private readonly VanHorn_NET_Final.Models.DomainContext _context;

        public CreateModel(VanHorn_NET_Final.Models.DomainContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Submission Submission { get; set; } = new Submission();
        public Quiz Quiz { get; set; }
        public async Task<IActionResult> OnGetAsync(int? quizId)
        {
            //if (quizId == null)
            //{
            //    return NotFound();
            //}
            //Quiz = await _context.Quizzes.FirstOrDefaultAsync(m => m.QuizId == quizId);
            //if (Quiz == null)
            //{
            //    return NotFound();
            //}
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "lastName");
            ViewData["QuizId"] = new SelectList(_context.Quizzes, "QuizId", "QuizName");
            return Page();
        }
        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            _context.Submissions.Add(Submission);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Submissions/Edit", new { id = Submission.SubId, questionCount = 0, qid = Submission.QuizId });
        }
    }
}