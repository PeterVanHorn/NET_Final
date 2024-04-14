using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
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
        public IEnumerable<Question> questionresults { get; set; }
        public async Task OnGet()
        {
            questionresults = await _context.Questions.ToListAsync();
        }
    }
}
