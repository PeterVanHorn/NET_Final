using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using VanHorn_NET_Final.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace VanHorn_NET_Final.Pages.Questions
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
            return Page();
        }

        [BindProperty]
        public Question Question { get; set; } = default!;

        [BindProperty]
        public int QuizId { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(int quizId)
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}
            Question question = new Question
            {
                QuizId = quizId,
                QuestionText = Question.QuestionText
            };

            _context.Questions.Add(question);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Options/Create", new { questionId = question.QuestionId});
        }
    }
}