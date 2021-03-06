using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Schema;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vancouver.Aids;
using Vancouver.CustomerFolder;
using Vancouver.DbContext;
using Vancouver.FlightsFolder;
using Vancouver.Models;
using Vancouver.Services;

namespace Vancouver
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ITicketPurchaseService, TicketPurchaseService>();
            services.AddSingleton<IEmailSender, EmailService>();
            services.AddScoped<IFlightsObjectsRepository, FlightsObjectsRepository>();
            services.AddSingleton<IAirportInfoService, AirportInfoService>();
            services.AddSingleton<ITimeZoneService, TimeZoneService>();
            services.AddSingleton<IAircraftInfoService, AircraftInfoService>();
            services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");
            services.AddDbContext<VancouverDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<ApplicationUser, IdentityRole>(config =>
                    {
                        //config.SignIn.RequireConfirmedEmail = true;
                        config.Password.RequireNonAlphanumeric = false;
                    })
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<VancouverDbContext>();

           services.AddCors();
            //.AddDefaultTokenProviders()

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc()
            .AddRazorPagesOptions(options => { options.Conventions.AuthorizePage("/MyAccount");  })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddTransient<ICustomersRepository, CustomersRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseStatusCodePagesWithRedirects("/errors/notfound");
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc();
            CreateRolesAndAdminUser(serviceProvider);
        }
        private static void CreateRolesAndAdminUser(IServiceProvider serviceProvider)
        {
            const string adminRoleName = "Administrator";
            string[] roleNames = { adminRoleName, "User" };

            foreach (string roleName in roleNames)
            {
                CreateRole(serviceProvider, roleName);
            }

            // Get these value from "appsettings.json" file.
            string adminUserEmail = "admin@admin.com;//admin email";
            string adminPwd = "V4n.Couver";//admin password
            AddUserToRole(serviceProvider, adminUserEmail, adminPwd, adminRoleName);
        }

        private static void CreateRole(IServiceProvider serviceProvider, string roleName)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            Task<bool> roleExists = roleManager.RoleExistsAsync(roleName);
            roleExists.Wait();

            if (!roleExists.Result)
            {
                Task<IdentityResult> roleResult = roleManager.CreateAsync(new IdentityRole(roleName));
                roleResult.Wait();
            }
        }
        
        private static void AddUserToRole(IServiceProvider serviceProvider, string userEmail,
            string userPwd, string roleName)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            Task<ApplicationUser> checkAppUser = userManager.FindByEmailAsync(userEmail);
            checkAppUser.Wait();

            ApplicationUser appUser = checkAppUser.Result;

            if (checkAppUser.Result == null)
            {
                ApplicationUser newAppUser = new ApplicationUser
                {
                    Email = userEmail,
                    UserName = "AdminUser",
                    FirstName = "Admin",
                    LastName = "User"
                };

                Task<IdentityResult> taskCreateAppUser = userManager.CreateAsync(newAppUser, userPwd);
                taskCreateAppUser.Wait();
                
                if (taskCreateAppUser.Result.Succeeded)
                {
                    appUser = newAppUser;
                }
            }

            Task<IdentityResult> newUserRole = userManager.AddToRoleAsync(appUser, roleName);
            newUserRole.Wait();
        }
    }
}
