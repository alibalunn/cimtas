using LeaveTrack.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using LeaveTrack.Persistence;
using LeaveTrack.Filters;
using Microsoft.AspNetCore.Authentication.Cookies;  // Bu satýrý unutma

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string connectionString = builder.Configuration.GetSection("ConnectionStrings")["DefaultConnection"];
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<GlobalErrorExceptionFilter>();
builder.Services.AddRepositories();
builder.Services.AddServices();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/";
        options.AccessDeniedPath = "/Account/AccessDenied";
    });

builder.Services.AddAuthorization();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "root",
    pattern: "",
    defaults: new { controller = "Auth", action = "Login" });

app.Run();
