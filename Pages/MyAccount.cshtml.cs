using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Vancouver.CustomerFolder;
using Vancouver.Databases;
using Vancouver.Models;

namespace Vancouver.Pages
{
    public class MyAccountModel : PageModel
    {
        private IHostingEnvironment _environment;
        private SignInManager<ApplicationUser> _signInManager;
        private UserManager<ApplicationUser> _userManager;

        public MyAccountModel(IHostingEnvironment environment, 
            SignInManager<ApplicationUser> signInManager, 
            UserManager<ApplicationUser> userManager)
            
        {
            _environment = environment;
            _signInManager = signInManager;
            _userManager = userManager;

        }

        

        [BindProperty]
        public IFormFile Upload { get; set; }
        [BindProperty]
        public string FullFileName { get; set; }
        [BindProperty]
        public string UserPhotoPath { get; set; }

        public async Task OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            string extension = Upload.FileName;
            string[] extensionHelper = extension.Split('.');
            extension = "." + extensionHelper[1];
            string fileName = _userManager.GetUserId(User) + extension;
            var file = _environment.ContentRootPath + "/wwwroot/uploads/usrImg";
            FullFileName = Path.Combine(file, fileName);
            UserPhotoPath = fileName;
            user.UserPhoto = UserPhotoPath;
            
            using (var fileStream = new FileStream(FullFileName, FileMode.Create))
            {
                await Upload.CopyToAsync(fileStream);
            }

            await _userManager.UpdateAsync(user);
            await _signInManager.RefreshSignInAsync(user);
        }

        public void OnGet()
        {

        }

    
    }
}