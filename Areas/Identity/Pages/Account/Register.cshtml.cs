using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Vancouver.Models;
using Vancouver.Services;

namespace Vancouver.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailService;
        private IHostingEnvironment _environment;


        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailService,
            IHostingEnvironment environment)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailService = emailService;
            _environment = environment;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "First name")]
            public string FirstName { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Last name")]
            public string LastName { get; set; }

            [Required]
            [DataType(DataType.Date)]
            [Display(Name = "Date of birth")]
            public DateTime DateOfBirth { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [DataType(DataType.PhoneNumber)]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [BindProperty]
            [Display(Name = "Add a profile picture")]
            public IFormFile UserPhoto { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public string FullFileName { get; set; }
        public string UserPhotoPath { get; set; }

        public async Task<IActionResult> OnPostAjaxRegister(string returnUrl = null)
        {
            string ajaxPostEmail = "";
            string ajaxPostFirstName = "";
            string ajaxPostLastName = "";
            string ajaxPostDateOfBirth = "";
            string ajaxPostPassword = "";
            string ajaxPostAgree = "";

            

            MemoryStream stream = new MemoryStream();
            Request.Body.CopyTo(stream);
            stream.Position = 0;
            using (StreamReader reader = new StreamReader(stream))
            {
                string requestBody = reader.ReadToEnd();

                if (requestBody.Length > 0)
                {
                    var obj = JsonConvert.DeserializeObject<RegisterPostData>(requestBody);
                    if (obj == null)
                    {
                        Console.WriteLine("FAIIIIL");
                    }
                    if (obj != null)
                    {
                        ajaxPostFirstName = obj.InputFirstName;
                        ajaxPostLastName = obj.InputLastName;
                        ajaxPostDateOfBirth = obj.InputDateOfBirth;
                        ajaxPostEmail = obj.InputEmail;
                        ajaxPostPassword = obj.InputPassword;
                        ajaxPostAgree = obj.InputAcceptTerms;
                    }
                }
            }

            Input.DateOfBirth = DateTime.ParseExact(ajaxPostDateOfBirth,
                new string[] {"dd/MM/yyyy", "d/M/yyyy", "d/MM/yyyy", "dd/M/yyyy"}, CultureInfo.InvariantCulture);
            Input.FirstName = ajaxPostFirstName;
            Input.LastName = ajaxPostLastName;
            Input.Email = ajaxPostEmail;
            Input.Password = ajaxPostPassword;

            var user = new ApplicationUser { FirstName = Input.FirstName, LastName = Input.LastName, DateOfBirth = Input.DateOfBirth, UserName = Input.Email, Email = Input.Email, PhoneNumber = Input.PhoneNumber };

            var result = await _userManager.CreateAsync(user, Input.Password);
            if (result.Succeeded)
            {
                var roleResult = await _userManager.AddToRoleAsync(user, "User");
                _logger.LogInformation("User created a new account with password.");

                var emailToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var callbackUrl = Url.Page(
                    "/Account/ConfirmEmail",
                    pageHandler: null,
                    values: new { userId = user.Id, code = emailToken },
                    protocol: Request.Scheme);

                //await _emailService.SendEmailAsync(Input.Email, "Confirm your email",
                //$"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");



                //await _signInManager.SignInAsync(user, isPersistent: false);
                return new JsonResult("Register Success!");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
                return new JsonResult("Register failed!");
                
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

        


    


        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { FirstName = Input.FirstName, LastName = Input.LastName, DateOfBirth = Input.DateOfBirth, UserName = Input.Email, Email = Input.Email, PhoneNumber = Input.PhoneNumber };

                if (Input.UserPhoto != null)
                {
                    string extension = Input.UserPhoto.FileName;
                    string[] extensionHelper = extension.Split('.');
                    extension = "." + extensionHelper[1];
                    string fileName = user.Id + extension;
                    var file = _environment.ContentRootPath + "/wwwroot/uploads/usrImg";
                    FullFileName = Path.Combine(file, fileName);
                    UserPhotoPath = fileName;
                    user.UserPhoto = UserPhotoPath;
                    bool directoryExist = System.IO.Directory.Exists(file);

                    if (!directoryExist)
                    {
                        Directory.CreateDirectory(file);
                    }


                    using (var fileStream = new FileStream(FullFileName, FileMode.Create))
                    {
                        await Input.UserPhoto.CopyToAsync(fileStream);
                    }
                }

                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(user, "User");
                    _logger.LogInformation("User created a new account with password.");

                    var emailToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { userId = user.Id, code = emailToken },
                        protocol: Request.Scheme);

                    //await _emailService.SendEmailAsync(Input.Email, "Confirm your email",
                        //$"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");


                    //await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
               
                
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                
                
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }

    public class RegisterPostData
    {
        public string InputEmail { get; set; }
        public string InputPassword { get; set; }
        public string InputDateOfBirth { get; set; }
        public string InputFirstName { get; set; }
        public string InputLastName { get; set; }
        public string InputAcceptTerms { get; set; }
    }
}
