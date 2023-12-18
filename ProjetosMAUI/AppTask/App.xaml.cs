using AppTask.Database.Repositories;
using AppTask.Libraries.Authentations;
using AppTask.Services;
using AppTask.Views;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Platform;

namespace AppTask
{
    public partial class App : Application
    {        
        public App(IServiceProvider serviceProvider)
        {
            CustomHandler();

            InitializeComponent();

            if(UserAuth.GetUserLogged() == null)
            {
                var page = serviceProvider.GetRequiredService<LoginPage>();
                MainPage = page;
            }
            else
            {
                var page = serviceProvider.GetRequiredService<StartPage>();
                MainPage = page;
            }
            
        }
        private void CustomHandler()
        {
            EntryNoBorder();
            DatePickerNoBorder();
        }

        private static void EntryNoBorder()
        {
            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("NoBorder", (handler, view) =>
            {
#if ANDROID
                //ANDROID
                handler.PlatformView.BackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(Colors.Transparent.ToPlatform());
#elif IOS || MACCATALYST
                //iOS || MACCATALYST
                handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#elif WINDOWS
                //WINDOWS - Não funciona 100%
                handler.PlatformView.BorderThickness = new Thickness(0).ToPlatform();
#endif
            });
        }
        private static void DatePickerNoBorder()
        {
            Microsoft.Maui.Handlers.DatePickerHandler.Mapper.AppendToMapping("NoBorder", (handler, view) =>
            {
#if ANDROID
                //ANDROID
                handler.PlatformView.BackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(Colors.Transparent.ToPlatform());
#elif IOS || MACCATALYST
                //iOS || MACCATALYST
                //handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#elif WINDOWS
                //WINDOWS - Não funciona 100%
                handler.PlatformView.BorderThickness = new Thickness(0).ToPlatform();
#endif
            });
        }
    }
}