using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VanHorn_NET_Final.Models;

namespace VanHorn_NET_Final.Pages.Options
{
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
            Option = await _context.Options.ToListAsync();
        }
    }
}
