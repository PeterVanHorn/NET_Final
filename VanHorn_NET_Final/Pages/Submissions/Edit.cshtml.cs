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
    public class EditModel : PageModel
    {
        private readonly VanHorn_NET_Final.Models.DomainContext _context;

        public EditModel(VanHorn_NET_Final.Models.DomainContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Submission Submission { get; set; } = default!;
        public IList<Question> Questions { get; set; }
        public IList<Option> Options { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Questions = await _context.Questions.ToListAsync();
            Options = await _context.Options.ToListAsync();
            if (id == null)
            {
                return NotFound();
            }

            var submission =  await _context.Submission.FirstOrDefaultAsync(m => m.SubId == id);
            if (submission == null)
            {
                return NotFound();
            }
            Submission = submission;
           ViewData["StudentId"] = new SelectList(_context.Student, "StudentId", "StudentId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

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

            return RedirectToPage("./Index");
        }

        private bool SubmissionExists(int id)
        {
            return _context.Submission.Any(e => e.SubId == id);
        }
    }
}
