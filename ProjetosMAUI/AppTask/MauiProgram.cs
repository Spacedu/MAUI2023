using AppTask.Database;
using AppTask.Database.Repositories;
using AppTask.Services;
using Microsoft.Extensions.Logging;

namespace AppTask
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
            builder.Services.AddDbContext<AppTaskContext>();
            builder.Services.AddScoped<IUserModelRepository, UserModelRepository>();
            builder.Services.AddScoped<ITaskModelRepository, TaskModelRepository>();
            builder.Services.AddScoped<HttpClient>(options => {
                HttpClient http = new HttpClient();
                http.BaseAddress = new Uri(AppSettings.EndpointAPI);
                return http;
            });
            builder.Services.AddScoped<UserService>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}