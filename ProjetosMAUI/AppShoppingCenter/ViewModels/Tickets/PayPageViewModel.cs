using AppShoppingCenter.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppShoppingCenter.ViewModels.Tickets
{
    public partial class PayPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private Ticket ticket; 
    }
}
