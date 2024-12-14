using Microsoft.Extensions.Logging;
using TrackYourself.Models.ViewModels;
using TrackYourself.Services;

namespace TrackYourself
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiMaps()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();

            // Register Services
            builder.Services.AddSingleton<LocationService>();

            // Register ViewModels
            builder.Services.AddTransient<MainPageViewModel>();

            // Register Views
            builder.Services.AddTransient<MainPage>();

            builder.Services.AddSingleton<DatabaseService>();

#endif

            return builder.Build();
        }
    }
}
