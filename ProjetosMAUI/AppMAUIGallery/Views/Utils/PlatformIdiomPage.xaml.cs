namespace AppMAUIGallery.Views.Utils;

public partial class PlatformIdiomPage : ContentPage
{
	public PlatformIdiomPage()
	{
		InitializeComponent();

		#if WINDOWS
			DisplayAlert("Condições de Compilação", "Esta mensagem de executada só no Windows usando Condições de Compilação", "OK");
		#endif


        if (Device.RuntimePlatform == Device.WinUI)
		{
			DisplayAlert("Windows", "Esta mensagem é exclusiva do Windows", "OK");
		}

		if(Device.Idiom == TargetIdiom.Desktop)
		{
			DisplayAlert("Desktop", "Esta mensagem é exclusiva do Desktop/PC", "OK");
		}
	}
}