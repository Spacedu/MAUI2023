namespace AppMAUIGallery.Views.Components.Mains;

public partial class ButtonPage : ContentPage
{
	public ButtonPage()
	{
		InitializeComponent();
	}

    private void Button_Pressed(object sender, EventArgs e)
    {
        LblLog.Text += $"\nPressionado: {DateTime.Now}";
    }

    private void Button_Released(object sender, EventArgs e)
    {
        LblLog.Text += $"\nLiberado: {DateTime.Now}";
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        LblLog.Text += $"\nClicado: {DateTime.Now}";
    }
}