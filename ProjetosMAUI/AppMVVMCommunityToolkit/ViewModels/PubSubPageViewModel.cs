using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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

        }
    }
}
