//Peter Van Horn
//.NET Final Project
//05/03/2024

using Microsoft.EntityFrameworkCore;
using VanHorn_NET_Final.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<DomainContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection")));

// added this in startup file initially but this seems to work
builder.Services.AddAuthentication("MyCookieAuth").AddCookie("MyCookieAuth", options =>
{
    options.Cookie.Name = "MyCookieAuth";
    options.LoginPath = "/account/login";
    options.AccessDeniedPath = "/Account/AccessDenied";
});

// so far this is the only policy I am using but adding more is pretty easy
builder.Services.AddAuthorization(Options =>
{
    Options.AddPolicy("TeacherOnly",
        policy => policy.RequireClaim("Teacher"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.Run();