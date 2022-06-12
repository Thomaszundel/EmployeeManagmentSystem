using Microsoft.EntityFrameworkCore;
using EmployeeManagmentSystem.Models;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddDbContext<EmpManagerDbContext>(opts => { 
    opts.UseSqlServer(builder.Configuration["ConnectionStrings:EmployeeManagerConnection"]);
    opts.EnableSensitiveDataLogging(true);
});
    
builder.Services.AddSingleton<EmployeeManagmentSystem.Services.ToggleService>();

builder.Services.AddDbContext<IdentityContext>(opts => opts.UseSqlServer(builder.Configuration["ConnectionStrings:IdentityConnection"]));
builder.Services.AddIdentity<IdentityUser,IdentityRole>().AddEntityFrameworkStores<IdentityContext>();
builder.Services.Configure<IdentityOptions>(opts =>
{
    opts.Password.RequiredLength = 6;
    opts.Password.RequireNonAlphanumeric = false;
    opts.Password.RequireLowercase = false;
    opts.Password.RequireUppercase = false;
    opts.Password.RequireDigit = false;
});

var app = builder.Build();

app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.UseAuthentication();

app.MapControllers();
app.MapControllerRoute("controllers", "controllers/{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.UseBlazorFrameworkFiles("/webassembly");
app.MapFallbackToFile("/webassembly/{*path:nonfile}", "/webassembly/index.html");

var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<EmpManagerDbContext>();
SeedData.SeedDatabase(context);
IdentitySeedData.CreateAdminAccount(app.Services, app.Configuration);

app.Run();
