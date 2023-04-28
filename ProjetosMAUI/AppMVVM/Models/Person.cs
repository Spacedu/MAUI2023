using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMVVM.Models
{
    public class Person : INotifyPropertyChanged
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged(nameof(Id)); }
        }
        private string _name;
        public string Name { 
            get { return _name; } 
            set { _name = value; OnPropertyChanged(nameof(Name)); } 
        }

        private string _email;
        public string Email { 
            get { return _email; }
            set { _email = value; OnPropertyChanged(nameof(Email)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
