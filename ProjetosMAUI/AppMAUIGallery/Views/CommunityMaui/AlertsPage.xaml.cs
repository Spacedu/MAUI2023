using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace AppMAUIGallery.Views.CommunityMaui;

public partial class AlertsPage : ContentPage
{
	public AlertsPage()
	{
		InitializeComponent();
	}

    private void OnButtonClicked_ShowSnackbar(object sender, EventArgs e)
    {
		//Configuração Visual
		var options = new SnackbarOptions
		{
			BackgroundColor = Colors.White,
			TextColor = Colors.Green,
		};
		//Criação do Objeto
		var snackbar = Snackbar.Make("Ocorreu um erro inesperado!", null, "OK", TimeSpan.FromSeconds(5), options);


		//Apresentação da Snack
		snackbar.Show();
    }
}