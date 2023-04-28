using AppMVVMCommunityToolkit.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AppMVVMCommunityToolkit.ViewModels
{
    public class StartPageViewModel
    {
        public ICommand SaveCommand { get; set; }
        public Person Person { get; set; }
        public ObservableCollection<Person> People { get; set; }
        public StartPageViewModel()
        {
            Person = new Person();
        }
    }
}
