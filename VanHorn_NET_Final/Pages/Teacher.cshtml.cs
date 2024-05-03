//Peter Van Horn
//.NET Final Project
//05/03/2024

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VanHorn_NET_Final.Pages
{
    [Authorize(Policy = "TeacherOnly")]
    public class TeacherModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
