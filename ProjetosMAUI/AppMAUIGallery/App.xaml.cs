namespace AppMAUIGallery
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Application.Current.RequestedThemeChanged += Current_RequestedThemeChanged;
            MainPage = new AppFlyout();
        }

        private void Current_RequestedThemeChanged(object sender, AppThemeChangedEventArgs e)
        {
            
            if(e.RequestedTheme == AppTheme.Light)            
                App.Current.MainPage.DisplayAlert("Troca de Tema", "Trocou para o Tema Claro", "Ok");
            else
                App.Current.MainPage.DisplayAlert("Troca de Tema", "Trocou para o Tema Escuro", "Ok");
            
        }
    }
}