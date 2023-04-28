using AppMVVMCommunityToolkit.Views;

namespace AppMVVMCommunityToolkit
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage( new StartPage() );
        }
    }
}