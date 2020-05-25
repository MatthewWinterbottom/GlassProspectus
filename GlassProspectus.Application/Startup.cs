using GlassProspectus.Repository;
using GlassProspectus.Services.AccountService;
using GlassProspectus.Services.AccountService.Interfaces;
using GlassProspectus.Services.UserService;
using GlassProspectus.Services.UserService.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;

namespace GlassProspectus.Application
{
    public class Startup
    {
        private readonly IConfiguration config;
        private readonly string solutionDirectoryFilePath;

        public Startup(IConfiguration config)
        {
            this.config = config;
            var currentDirectory = Environment.CurrentDirectory;
            solutionDirectoryFilePath = Directory.GetParent(currentDirectory).FullName;
        }

        public void ConfigureServices(IServiceCollection services) // Configure services for your container
        {
            services.AddControllers(); // Use Controller in routing

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = Path.Combine(solutionDirectoryFilePath, @"GlassProspectus.Frontend\ClientApp\build");
            });

            services.AddDbContext<UniDbContext>( // Add a Db Context
                options => options.UseSqlServer(config.GetConnectionString("UniDbConnection"))); // Set the connection string to the SQL server

            services.AddAuthentication(); // Add Authentication of Users

            services.AddAuthorization(); // Allow Authorisation of Users

            services.AddIdentity<IdentityUser, IdentityRole>() // Add Microsoft Identity so we can authenticate users and track them
                .AddEntityFrameworkStores<UniDbContext>(); // Assign the Identity to user EFcore

            services.ConfigureApplicationCookie(config =>
            {
                config.LoginPath = "/Home/Index"; // Set a default path if a user is not authorised for the particular request
            });

            services.Configure<IdentityOptions>(config =>
            {
                // Password options
                config.Password.RequiredLength = 6;
                config.Password.RequireUppercase = false;
                config.Password.RequireLowercase = false;
                config.Password.RequireNonAlphanumeric = false;
            });

            // Register Dependencies
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAccountService, AccountService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) // configure the HTTP request pipeline.
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage(); // Generate HTML pages with the developer response

            app.UseHttpsRedirection(); // Accept http requests and convert them to https

            app.UseStaticFiles(); // We need this for the static React files

            app.UseSpaStaticFiles(); // We need this for the static react files

            app.UseRouting(); // We can route HTTP requests

            app.UseAuthentication(); // We can authenticate users when when mapping the HTTP requests

            app.UseAuthorization(); // We map requests using authorization (can they make requests to a particular endpoint)

            app.UseEndpoints(endpoints => // Set up default mapping for controllers
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            // Render out our react files
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = Path.Combine(solutionDirectoryFilePath, @"GlassProspectus.Frontend\ClientApp");

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
