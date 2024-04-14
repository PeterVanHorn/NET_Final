using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VanHorn_NET_Final.Models;

namespace VanHorn_NET_Final.Pages.Quizzes
{
    [Authorize(Policy = "TeacherOnly")]
    public class DetailsModel : PageModel
    {
        private readonly VanHorn_NET_Final.Models.DomainContext _context;

        public DetailsModel(VanHorn_NET_Final.Models.DomainContext context)
        {
            _context = context;
        }

        public Quiz Quiz { get; set; } = default!;
        public IList<Question> Questions { get; set; } = default!;
        public IList<Option> Options { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Questions = await _context.Questions.ToListAsync();
            Options = await _context.Options.ToListAsync();

            if (id == null)
            {
                return NotFound();
            }

            var quiz = await _context.Quizzes.FirstOrDefaultAsync(m => m.QuizId == id);
            if (quiz == null)
            {
                return NotFound();
            }
            else
            {
                Quiz = quiz;
            }
            return Page();
        }
    }
}