namespace AppTabbedPage
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new TabbedPageMenu();
        }
    }
}