using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Vancouver.Databases;
using Vancouver.Models;

namespace Vancouver.Pages.Admin
{
    [Authorize(Roles = "Administrator")]
    public class AdminPageModel : PageModel
    {

        private readonly VancouverDbContext _context;
        public UserManager<ApplicationUser> _userManager;
        public SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _applicationUsers;
        public AdminPageModel(VancouverDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext applicationUsers)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _applicationUsers = applicationUsers;
        }
        public void OnGetAsync()
        {
           
        }

        public async Task<List<ApplicationUser>> OnGetUsers()
        {
           return await _context.ApplicationUsers.ToListAsync();
        }
    }
}