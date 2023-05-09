namespace AppMAUIGallery.Views.Shells.Pages;

public partial class Page01 : ContentPage
{
	public Page01()
	{
		InitializeComponent();
	}

    private void GoToStep01(object sender, EventArgs e)
    {
		//Relativa: /page01+/page01step01
		Shell.Current.GoToAsync("page01step01");
    }
}