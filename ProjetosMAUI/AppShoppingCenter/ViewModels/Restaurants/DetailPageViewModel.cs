using AppShoppingCenter.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppShoppingCenter.ViewModels.Restaurants
{
    [QueryProperty(nameof(Establishment), "establishment")]
    public partial class DetailPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private Establishment establishment;

        [RelayCommand]
        private void OnTapToBack()
        {
            Shell.Current.GoToAsync("..");
        }
    }
}
