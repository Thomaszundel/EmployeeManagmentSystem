using Microsoft.EntityFrameworkCore;

using EmployeeManagmentSystem.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<EmpManagerDbContext>(opts =>
    opts.UseSqlServer(
        builder.Configuration["ConnectionStrings:EmployeeManagerConnection"]));

builder.Services.AddScoped<IEmployeeRepository,EFEmployeeRepository>();
var app = builder.Build();


app.UseStaticFiles();
app.MapDefaultControllerRoute();

SeedData.EnsurePopulated(app);

app.Run();
