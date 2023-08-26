using Fran.Gdi.CarFleet.Data;
using Fran.Gdi.CarFleet.Models;
using Fran.Gdi.CarFleet.Services;
using Fran.Gdi.CarFleet.Services.Implementations;

using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;

namespace Fran.Gdi.CarFleet
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors();

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString(Constants.Configuration.KEY_MAIN_DB_CONNECTION_STRING)
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services
                .AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services
                .AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

            builder.Services
                .AddAuthentication()
                .AddIdentityServerJwt();

            builder.Services
                .AddOpenApiDocument(opt => opt.Title = "Car Fleet");

            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();
            builder.Services.AddTransient<IDriversService, DriversService>();

            var app = builder.Build();

            app.UseCors(x =>
            {
                x.AllowAnyHeader();
                x.AllowAnyOrigin();
                x.AllowAnyMethod();
            });

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
                app.UseOpenApi();
                app.UseSwaggerUi3();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthentication();
            app.UseIdentityServer();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action=Index}/{id?}");
            
            app.MapRazorPages();

            app.MapFallbackToFile("index.html");

            app.Run();
        }
    }
}