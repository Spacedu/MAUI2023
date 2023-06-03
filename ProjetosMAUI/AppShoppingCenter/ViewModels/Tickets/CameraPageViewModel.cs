using AppShoppingCenter.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppShoppingCenter.ViewModels.Tickets
{
    public partial class CameraPageViewModel : ObservableObject
    {
        [RelayCommand]
        private void BarcodeDetected(string ticketNumber)
        {
            var service = App.Current.Handler.MauiContext.Services.GetService<TicketService>();
            var ticket = service.GetTicket(ticketNumber);

            if (ticket == null)
            {
                App.Current.MainPage.DisplayAlert("Ticket não encontrado!", $"Não localizamos um ticket com o número {ticketNumber}.", "OK");
                return;
            }

            var param = new Dictionary<string, object>()
            {
                { "ticket", ticket }
            };

            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await Shell.Current.GoToAsync("../pay", param);
            });
        }
    }
}
