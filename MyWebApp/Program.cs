using Microsoft.EntityFrameworkCore;
using HotelLibrary;
using HotelLibrary.data; // Ensure this matches the namespace of your context class
using HotelLibrary.Repositories; // Make sure this matches the namespace where IRoomRepository and RoomRepository are defined

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Configure the database context to use SQL Server
builder.Services.AddDbContext<HotellContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register the repository
builder.Services.AddScoped<IRoomRepository, RoomRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
