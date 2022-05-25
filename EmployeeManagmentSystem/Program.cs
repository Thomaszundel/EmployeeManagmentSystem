using Microsoft.EntityFrameworkCore;
using EmployeeManagmentSystem.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddDbContext<EmpManagerDbContext>(opts => { 
    opts.UseSqlServer(builder.Configuration["ConnectionStrings:EmployeeManagerConnection"]);
    opts.EnableSensitiveDataLogging(true);
});
    
builder.Services.AddSingleton<EmployeeManagmentSystem.Services.ToggleService>();

var app = builder.Build();

app.UseStaticFiles();
app.MapControllers();
app.MapControllerRoute("controllers", "controllers/{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<EmpManagerDbContext>();
SeedData.SeedDatabase(context);

app.Run();
