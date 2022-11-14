namespace AppFlyoutPage;

public partial class Menu : ContentPage
{
	public Menu()
	{
		InitializeComponent();
	}

    private void OnButtonClickedPage1(object sender, EventArgs e)
    {
        ((FlyoutPage)App.Current.MainPage).Detail = new Page1();
    }

    private void OnButtonClickedPage2(object sender, EventArgs e)
    {
        ((FlyoutPage)App.Current.MainPage).Detail = new Page2();
    }

    private void OnButtonClickedPage3(object sender, EventArgs e)
    {
        ((FlyoutPage)App.Current.MainPage).Detail = new Page3();
    }
}