using AppMVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMVVM.ViewModels
{
    public class StartPageViewModel
    {
        public Person Person { get; set; }
        public StartPageViewModel()
        {
            Person = new Person();
        }
    }
}
