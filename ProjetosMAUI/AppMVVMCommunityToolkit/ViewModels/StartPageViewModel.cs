using AppMVVMCommunityToolkit.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AppMVVMCommunityToolkit.ViewModels
{
    public partial class StartPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private Person person;
        public ObservableCollection<Person> People { get; set; }
        public StartPageViewModel()
        {
            Person = new Person();
            People = new ObservableCollection<Person>();
        }

        [RelayCommand]
        private void Save()
        {
            People.Add(Person);
            Person = new Person();
        }
    }
}
