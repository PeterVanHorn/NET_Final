//Peter Van Horn
//.NET Final Project
//05/03/2024
//this is disguised as something else to the user.
//it is the process of taking the quiz during which the student(or teacher) 
//creates a submission


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
        public IActionResult OnGet()
        {
            _context.Database.EnsureCreated();
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "LastName");
            ViewData["QuizId"] = new SelectList(_context.Quizzes, "QuizId", "QuizName");
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (Submission.Answers == null)
            {
                Submission.Answers = new List<Answer>();
            }

            _context.Submissions.Add(Submission);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Submissions/Edit", new { id = Submission.SubId, quizId = Submission.QuizId, questionCount = 0 });
        }
    }
}