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
    public class IndexModel : PageModel
    {
        private readonly VanHorn_NET_Final.Models.DomainContext _context;

        public IndexModel(VanHorn_NET_Final.Models.DomainContext context)
        {
            _context = context;
        }

        public IList<Option> Option { get;set; } = default!;

        public async Task OnGetAsync()
        {
            _context.Database.EnsureCreated();
            Option = await _context.Options.ToListAsync();
        }
    }
}
