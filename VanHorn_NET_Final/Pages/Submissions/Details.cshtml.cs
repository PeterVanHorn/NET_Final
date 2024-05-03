//Peter Van Horn
//.NET Final Project
//05/03/2024
//not meaningfully modified over the scaffolded

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VanHorn_NET_Final.Models;

namespace VanHorn_NET_Final.Pages.Submissions
{
    [Authorize(Policy = "TeacherOnly")]
    public class DetailsModel : PageModel
    {
        private readonly VanHorn_NET_Final.Models.DomainContext _context;

        public DetailsModel(VanHorn_NET_Final.Models.DomainContext context)
        {
            _context = context;
        }

        public Submission Submission { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var submission = await _context.Submissions
                .Include(s => s.Student)
                .Include(o => o.Answers)
                .FirstOrDefaultAsync(m => m.SubId == id);
            if (submission == null)
            {
                return NotFound();
            }
            else
            {
                Submission = submission;
            }
            return Page();
        }
    }
}
