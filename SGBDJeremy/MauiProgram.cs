using Microsoft.Extensions.Logging;
using SGBDJeremy.DAL;
using SGBDJeremy.DAL.Interfaces;
using SGBDJeremy.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;


namespace SGBDJeremy
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
            //singleton ci dessous ↓↓↓ injection par après dans ClientHomeViewModel.cs
            builder.Services.AddSingleton<IMeetingRepository, MeetingRepository>();


#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
