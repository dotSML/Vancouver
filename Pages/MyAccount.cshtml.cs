using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
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
        public VancouverDbContext _context;
        public ICustomersRepository _customersRepository;

        public MyAccountModel(IHostingEnvironment environment,
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            VancouverDbContext context,
            ICustomersRepository customersRepository)

        {
            _environment = environment;
            _signInManager = signInManager;
            _userManager = userManager;
            _context = context;
            _customersRepository = customersRepository;

        }



        [BindProperty] public IFormFile Upload { get; set; }
        [BindProperty] public string FullFileName { get; set; }
        [BindProperty] public string UserPhotoPath { get; set; }
        [BindProperty] public Customer Traveler { get; set; }
        public IEnumerable<Customer> Travelers { get; set; }

        public void OnGet()
        {
            AddDefaultTraveler();
            var userId = _userManager.GetUserId(User);
            Travelers = _context.Customers.Include(x => x.Passport).Where(r => r.ApplicationUserId == userId).ToList();
        }

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
            bool directoryExists = System.IO.Directory.Exists(file);

            if (!directoryExists)
            {
                Directory.CreateDirectory(file);
            }


            if (System.IO.File.Exists(FullFileName))
            {
                System.IO.File.Delete(FullFileName);
            }


            using (var fileStream = new FileStream(FullFileName, FileMode.Create))
            {
                await Upload.CopyToAsync(fileStream);
            }

            await _userManager.UpdateAsync(user);
            await _signInManager.RefreshSignInAsync(user);
        }

        public async Task OnPostDeletePhoto()
        {
            var user = await _userManager.GetUserAsync(User);
            var fullPath = _environment.ContentRootPath + "/wwwroot/uploads/usrImg/" + user.UserPhoto;
            System.IO.File.Delete(fullPath);
            user.UserPhoto = null;
            await _userManager.UpdateAsync(user);
            await _signInManager.RefreshSignInAsync(user);
            Response.Redirect("/MyAccount");
        }

        public async Task OnPostAddTraveler(Customer traveler)
        {
            var travelerObject = traveler;
            var user = await _userManager.GetUserAsync(User);
            travelerObject.ApplicationUserId = user.Id;
            _customersRepository.SetCustomerPassport(travelerObject);

            _context.Add(travelerObject);
            _context.SaveChanges();
            await _userManager.UpdateAsync(user);
            await _signInManager.RefreshSignInAsync(user);
            Response.Redirect("/MyAccount");
        }

        public async Task OnPostDeleteTraveler(string id)
        {
            var traveler = _context.Customers.Include(p => p.Passport).FirstOrDefault(x => x.CustomerId == id);
            var passport = traveler.Passport;
            if (traveler != null)
            {
                _context.Customers.Remove(traveler);
                _context.Passports.Remove(passport);

                await _context.SaveChangesAsync();
            }

            Response.Redirect("/MyAccount");
        }

        public ActionResult OnPostUpdateTraveler()
        {
            {
                MemoryStream stream = new MemoryStream();
                Request.Body.CopyTo(stream);
                stream.Position = 0;
                using (StreamReader reader = new StreamReader(stream))
                {
                    string requestBody = reader.ReadToEnd();
                    if (requestBody.Length > 0)
                    {

                        var obj = JsonConvert.DeserializeObject<Customer>(requestBody);
                        if (obj != null)
                        {
                            var traveler = _context.Customers.AsNoTracking().FirstOrDefault(x => x.CustomerId == obj.CustomerId);

                            var updatedTraveler = obj;

                            _context.Customers.Update(updatedTraveler);
                            _context.SaveChanges();
                        }
                    }
                }
            }

            return new JsonResult("Success!");
        }


        public void AddDefaultTraveler()
        {

            if (_signInManager.IsSignedIn(User))
            {
                var user = _userManager.GetUserAsync(User);
                var userTravelers = _context.Customers.Any(x => x.ApplicationUserId == user.Result.Id);

                if (!userTravelers)
                {
                    var traveler = new Customer
                    {
                        ApplicationUserId = user.Result.Id,
                        FirstName = user.Result.FirstName,
                        LastName = user.Result.LastName,
                        DateOfBirth = user.Result.DateOfBirth,
                        Email = user.Result.Email,
                        Primary = true
                    };

                    _context.Customers.Add(traveler);
                    _context.SaveChanges();
                }
            }

        }
    }

}





