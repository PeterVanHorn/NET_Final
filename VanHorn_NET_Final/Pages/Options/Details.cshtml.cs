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

namespace VanHorn_NET_Final.Pages.Options
{
    [Authorize(Policy = "TeacherOnly")]
    public class DetailsModel : PageModel
    {
        private readonly VanHorn_NET_Final.Models.DomainContext _context;

        public DetailsModel(VanHorn_NET_Final.Models.DomainContext context)
        {
            _context = context;
        }

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
    }
}
