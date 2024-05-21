using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Maui.ViewModels;
using Maui.Views;
using HotelLibrary.data;
using HotelLibrary.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Maui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // Register the database context
            builder.Services.AddDbContext<HotellContext>(options =>
                options.UseSqlServer("Server=tcp:dat154-hotel.database.windows.net,1433;Initial Catalog=HotelDatabase;Persist Security Info=False;User ID=MadsenTesdal;Password=DAT154fun;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));

            // Register repositories
            builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
            builder.Services.AddScoped<ITaskRepository, TaskRepository>();
            builder.Services.AddScoped<IRoomRepository, RoomRepository>();

            // Register ViewModels
            builder.Services.AddTransient<MainViewModel>();
            builder.Services.AddTransient<CleanerViewModel>();
            builder.Services.AddTransient<ServicePersonViewModel>();
            builder.Services.AddTransient<MaintainerViewModel>();

            // Register Views
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<CleanerPage>();
            builder.Services.AddTransient<ServicePersonPage>();
            builder.Services.AddTransient<MaintainerPage>();

            return builder.Build();
        }
    }
}
