using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppShoppingCenter.ViewModels.Tickets
{
    public partial class ScanPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private string ticketNumber;

        [RelayCommand]
        private void Scan()
        {
            //TODO - Abrir a camera
            Shell.Current.GoToAsync("pay");
        }

        [RelayCommand]
        private void CheckTicketNumber()
        {
            if (TicketNumber?.Length < 12)
                return;

            Shell.Current.GoToAsync("pay");

            //TODO - Verificar se código existe no banco/API.

            //TODO - Navegar para página Pay.

            //TODO - Mensagem de alerta.
        }

        [RelayCommand]
        private void List()
        {
            Shell.Current.GoToAsync("list");
        }
    }
}
