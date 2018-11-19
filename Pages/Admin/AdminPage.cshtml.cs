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


        [HttpPost]
        public async Task<IActionResult> OnPostAddAdminRole(string id)
        {
            AddNewUserToRole(_provider, id, "Administrator");
            return Page();
        }
        private void AddNewUserToRole(IServiceProvider serviceProvider, string id,
            string roleName)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            Task<ApplicationUser> checkAppUser = userManager.FindByIdAsync(id);
            checkAppUser.Wait();
            if (checkAppUser.Result == null)
            {
                Message = "User not found";
            }
            Task<IdentityResult> newUserRole = userManager.AddToRoleAsync(checkAppUser.Result, roleName);
            newUserRole.Wait();

        }
    }

}