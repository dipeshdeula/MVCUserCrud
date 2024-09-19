using Microsoft.EntityFrameworkCore;
using MVCUserCrud.Models;
using MVCUserCrud.Repositories;
using MVCUserCrud.Security;
using MVCUserCrud.Services;

namespace MVCUserCrud
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();

            //Datbase Injection

            builder.Services.AddDbContext<MvcuserCrudContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });


            //Dependency Injection
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddSingleton<DataSecurityProvider>();

            var app = builder.Build();

            app.UseRouting();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                );

           

            app.Run();
        }
    }
}
