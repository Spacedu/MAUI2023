namespace AppNumeroDaSorte;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private void OnGenerateLuckNumbers(object sender, EventArgs e)
	{
		NameApp.IsVisible = false;
		ContainerLuckNumbers.IsVisible = true;
    }
}