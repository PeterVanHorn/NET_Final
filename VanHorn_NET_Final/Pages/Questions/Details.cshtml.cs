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
using Microsoft.EntityFrameworkCore;
using VanHorn_NET_Final.Models;

namespace VanHorn_NET_Final.Pages.Questions
{
    [Authorize(Policy = "TeacherOnly")]
    public class DetailsModel : PageModel
    {
        private readonly VanHorn_NET_Final.Models.DomainContext _context;

        public DetailsModel(VanHorn_NET_Final.Models.DomainContext context)
        {
            _context = context;
        }

        public Question Question { get; set; } = default!;
        public IList<Option> Options { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Options = await _context.Options.ToListAsync();
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Questions.FirstOrDefaultAsync(m => m.QuestionId == id);
            if (question == null)
            {
                return NotFound();
            }
            else
            {
                Question = question;
            }
            return Page();
        }
    }
}
