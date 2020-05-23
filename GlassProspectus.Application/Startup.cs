using GlassProspectus.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GlassProspectus.Application
{
    public class Startup
    {
        private readonly IConfiguration config;
        public Startup(IConfiguration config) => this.config = config;

        public void ConfigureServices(IServiceCollection services) // Configure services for your container
        {
            services.AddControllers(); // Use Controller in routing

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
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) // configure the HTTP request pipeline.
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage(); // Generate HTML pages with the developer response

            app.UseRouting(); // We can route HTTP requests

            app.UseAuthentication(); // We can authenticate users when when mapping the HTTP requests

            app.UseAuthorization(); // We map requests using authorization (can they make requests to a particular endpoint)

            app.UseEndpoints(endpoints => // Set up default mapping for controllers
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
