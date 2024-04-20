using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using VanHorn_NET_Final.Models;

namespace VanHorn_NET_Final.Pages.Submissions
{
    public class EditModel : PageModel
    {
        private readonly VanHorn_NET_Final.Models.DomainContext _context;

        public EditModel(VanHorn_NET_Final.Models.DomainContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Submission Submission { get; set; } = default!;
        [BindProperty]
        public int SelectedOptionId { get; set; }
        [BindProperty]
        public Answer Answer { get; set; }
        [BindProperty]
        public IList<Answer> Answers { get; set; }
        [BindProperty]
        public IList<Question> Questions { get; set; }
        public IList<Option> Options { get; set; }
        public int QuestionCount { get; set; }
        public Quiz Quiz { get; set; }
        public Question Question { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, int? quizId, int questionCount)
        {
            var submission = await _context.Submissions
                .FirstOrDefaultAsync(m => m.SubId == id);
            Questions = await _context.Questions
                .Where(q => q.QuizId == quizId).ToListAsync();
            Options = await _context.Options.ToListAsync();
            QuestionCount = questionCount;
            if (id == null)
            {
                return NotFound();
            }

            
            if (submission == null)
            {
                return NotFound();
            }
            Submission = submission;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int questionCount)
        {
            //if (SelectedOptionId == 0)
            //{
            //    ModelState.AddModelError(string.Empty, "Please select an option.");
            //    return Page();
            //}
            questionCount++;
            if (Submission.Answers == null)
            {
                Submission.Answers = new List<Answer>();
            }
            var selectedOption = await _context.Options.FindAsync(SelectedOptionId);
            Answer answer = new Answer
            {
                AnswerText = selectedOption.OptionText,
                Correct = selectedOption.Correct
            };
            //Answer = answer;
            Submission.Answers.Add(answer);
            _context.Attach(Submission).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubmissionExists(Submission.SubId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            if (questionCount < Questions.Count)
            {
                return RedirectToPage("/Submissions/Edit", new { id = Submission.SubId, quizId = Submission.QuizId, questionCount });
            }
            else
            {
                // If all questions are answered, redirect to a different page
                return RedirectToPage("/Index", new {questionCount});
            }
        }

        private bool SubmissionExists(int id)
        {
            return _context.Submissions.Any(e => e.SubId == id);
        }
    }
}