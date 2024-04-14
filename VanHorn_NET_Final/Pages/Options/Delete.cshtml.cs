using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VanHorn_NET_Final.Models;

namespace VanHorn_NET_Final.Pages.Options
{
    [Authorize(Policy = "TeacherOnly")]
    public class DeleteModel : PageModel
    {
        private readonly VanHorn_NET_Final.Models.DomainContext _context;

        public DeleteModel(VanHorn_NET_Final.Models.DomainContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Option Option { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var option = await _context.Options.FirstOrDefaultAsync(m => m.OptionId == id);

            if (option == null)
            {
                return NotFound();
            }
            else
            {
                Option = option;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var option = await _context.Options.FindAsync(id);
            if (option != null)
            {
                Option = option;
                _context.Options.Remove(Option);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
