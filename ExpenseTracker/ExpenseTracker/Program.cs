using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ExpenseTracker.Data;
using Microsoft.AspNetCore.Identity; 

namespace ExpenseTracker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // 1. Configurare Bază de Date
            builder.Services.AddDbContext<ExpenseTrackerContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("ExpenseTrackerContext") ?? throw new InvalidOperationException("Connection string 'ExpenseTrackerContext' not found.")));

            // 2. ACTIVARE IDENTITY 
            builder.Services.AddDefaultIdentity<IdentityUser>(options => {
                options.SignIn.RequireConfirmedAccount = false; // Ca să nu ceară confirmare pe email
                options.Password.RequireDigit = false; // Parole mai simple pentru testare
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            })
            .AddEntityFrameworkStores<ExpenseTrackerContext>();

            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages(); // Necesar pentru paginile de login generate

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            // 3. ORDINEA CONTEAZĂ AICI:
            app.UseAuthentication(); // Cine ești?
            app.UseAuthorization();  // Ai voie aici?

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Transactions}/{action=Index}/{id?}");

            app.MapRazorPages(); 

            app.Run();
        }
    }
}