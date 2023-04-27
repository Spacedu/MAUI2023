using AppMVVM.Views;

namespace AppMVVM
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new StartPage();
        }
    }
}