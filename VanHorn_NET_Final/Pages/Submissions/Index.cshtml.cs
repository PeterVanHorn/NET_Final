using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VanHorn_NET_Final.Models;

namespace VanHorn_NET_Final.Pages.Submissions
{
    public class IndexModel : PageModel
    {
        private readonly VanHorn_NET_Final.Models.DomainContext _context;

        public IndexModel(VanHorn_NET_Final.Models.DomainContext context)
        {
            _context = context;
        }

        public IList<Submission> Submission { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Submission = await _context.Submission
                .Include(s => s.Student)
                .Include(u => u.Quiz).ToListAsync();
        }
    }
}
