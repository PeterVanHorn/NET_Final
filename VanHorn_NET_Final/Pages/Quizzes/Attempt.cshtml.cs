using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;
using VanHorn_NET_Final.Models;
using VanHorn_NET_Final.Pages.Account;

namespace VanHorn_NET_Final.Pages.Quizzes
{
    public class AttemptModel : PageModel
    {
        private readonly DomainContext _context;
        public AttemptModel(DomainContext context)
        {
            _context = context;
        }
        public IList<Question> Questions { get; set; } = default!;
        public IEnumerable<Option> Options { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Questions = await _context.Questions.ToListAsync();
            Options = await _context.Options.ToListAsync();

            if (id == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}