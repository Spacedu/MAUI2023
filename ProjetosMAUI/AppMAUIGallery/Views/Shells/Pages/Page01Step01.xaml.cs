namespace AppMAUIGallery.Views.Shells.Pages;

public partial class Page01Step01 : ContentPage
{
	public Page01Step01()
	{
		InitializeComponent();
	}

    private void GoBack(object sender, EventArgs e)
    {
        // Rota: /page01/page01step01

        Shell.Current.GoToAsync("..");
    }

    private void GoStep02(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("../page01step02");
    }
}