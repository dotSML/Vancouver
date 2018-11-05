using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Vancouver.Models;

namespace Vancouver.Pages.Admin
{
    [Authorize(Roles = "Administrator")]
    public class AdminPageModel : PageModel
    {
        

        public void OnGetAsync()
        {

        }
    }
}