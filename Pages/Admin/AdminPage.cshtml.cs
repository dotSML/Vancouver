using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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
        public IServiceProvider _provider;
        public string Message { get; set; }
        public IEnumerable<ApplicationUser> ApplicationUserList { get; set; }
        public AdminPageModel(VancouverDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IServiceProvider provider)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _provider = provider;
        }


        public IList<string> Roles { get; set; }

        public async Task<ActionResult> OnGet()
        {
            ApplicationUserList = _context.Users.ToList();

            foreach (var user in ApplicationUserList)
            {
                Roles = await _userManager.GetRolesAsync(user);

            }




            return Page();
        }

        public IList<string> RolesToRemove { get; set; }

        [HttpPost]
        public async Task<IActionResult> OnPostAddAdminRole(string id)
        {
             AddNewUserToRole(id, "Administrator");
            return RedirectToPage("AdminPage", "OnGet");
        }


        private async void AddNewUserToRole(string id,
            string roleName)
        {
            var user = _userManager.FindByIdAsync(id).Result;
            RolesToRemove = new List<string>(await _userManager.GetRolesAsync(user));

            await _userManager.RemoveFromRolesAsync(user, RolesToRemove);
            if (user == null)
            {
                Message = "User not found";
            }
            await _userManager.AddToRoleAsync(user, roleName);


        }
    }

}