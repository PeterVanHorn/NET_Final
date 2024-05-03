//Peter Van Horn
//.NET Final Project
//05/03/2024
//page is visited in the course of creating a new question, barely modified over the default scaffolding

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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

        [BindProperty]
        public Option Option { get; set; } = default!;

        [BindProperty]
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public int? QId { get; set; }
        public IActionResult OnGet(int? quizId)
        {
            QId = quizId;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int questionId)
        {
            Question = await _context.Questions
                .FirstOrDefaultAsync(u => u.QuestionId == questionId);
            Option option = new Option
            {
                QuestionId = questionId,
                OptionText = Option.OptionText,
                Correct = Option.Correct
            };

            _context.Options.Add(option);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Quizzes/Details", new  { id = Question.QuizId });
        }
    }
}