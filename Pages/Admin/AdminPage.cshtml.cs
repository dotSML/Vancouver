using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Vancouver.Aids;
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
        public IServiceProvider provider;
        public IEnumerable<ApplicationUser> ApplicationUserList { get; set; }
        public AdminPageModel(VancouverDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        

        public async Task<ActionResult> OnGet()
        {
            ApplicationUserList = _context.Users.ToList();
            return Page();
        }

        //public async Task<IActionResult> OnPostAddAdminRole()
        //{
        //    UserRoles.AddUserToRole(provider, );
        //}
    }
}