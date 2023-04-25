namespace AppMAUIGallery.Views.Styles;

public partial class AppThemeBindingPage : ContentPage
{
	public AppThemeBindingPage()
	{
		InitializeComponent();

		//Ler o Tema
		var Theme = Application.Current.RequestedTheme;

		Application.Current.UserAppTheme = AppTheme.Dark;
	}


}