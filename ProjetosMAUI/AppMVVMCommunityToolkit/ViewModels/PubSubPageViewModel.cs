using AppMVVMCommunityToolkit.Libraries.Messages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMVVMCommunityToolkit.ViewModels
{
    public partial class PubSubPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private string inputText;

        [RelayCommand]
        private void SendText()
        {
            WeakReferenceMessenger.Default.Send(new TextMessage(InputText));
        }
    }
}
