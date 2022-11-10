namespace AppNavigationPage;

public partial class Page3 : ContentPage
{
	public Page3()
	{
		InitializeComponent();
	}

    private void OnButtonPreviousClicked(object sender, EventArgs e)
    {
		Navigation.PopAsync();
    }
}