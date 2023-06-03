using AppShoppingCenter.Libraries.Storages;
using AppShoppingCenter.Services;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Windows.Networking.NetworkOperators;
using ZXing.Net.Maui.Controls;

namespace AppShoppingCenter
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseBarcodeReader()
                .UseMauiCommunityToolkit()
                .UseMauiCommunityToolkitMediaElement()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Light.ttf", "OpenSansLight");
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Bold.ttf", "OpenSansBold");
                });

            builder.Services.AddSingleton<TicketPreferenceStorage>();
            builder.Services.AddSingleton<StoreService>();
            builder.Services.AddSingleton<RestaurantService>();
            builder.Services.AddSingleton<CinemaService>();
            builder.Services.AddSingleton<TicketService>();
#if DEBUG
		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}