using HotelLibrary.data;
using HotelLibrary.Repositories;
using Maui.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;



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
            builder.Services.AddDbContext<HotellContext>(options =>
            options.UseSqlServer("Server=tcp:dat154-hotel.database.windows.net,1433;Initial Catalog=HotelDatabase;Persist Security Info=False;User ID=MadsenTesdal;Password=DAT154fun;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));

            builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
            builder.Services.AddScoped<ITaskRepository, TaskRepository>();
            builder.Services.AddScoped<IRoomRepository, RoomRepository>();

            builder.Services.AddTransient<MainViewModel>();
            builder.Services.AddTransient<CleanerViewModel>();
            builder.Services.AddTransient<ServicePersonViewModel>();
            builder.Services.AddTransient<MaintainerViewModel>();


            return builder.Build();
        }
    }
}
