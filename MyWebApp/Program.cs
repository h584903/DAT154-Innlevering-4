using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using HotelLibrary.data;
using HotelLibrary.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Configure the database context to use SQL Server
builder.Services.AddDbContext<HotellContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register the IRoomRepository implementation
builder.Services.AddScoped<IRoomRepository, RoomRepository>();

// Add session services
builder.Services.AddSession();

// Add authentication services and configure cookie authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/LogIn"; // Set the login path
        options.LogoutPath = "/Logout"; // Set the logout path
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

// Use authentication middleware
app.UseAuthentication();

app.UseAuthorization();

// Use session middleware
app.UseSession();

app.MapRazorPages();

app.Run();
