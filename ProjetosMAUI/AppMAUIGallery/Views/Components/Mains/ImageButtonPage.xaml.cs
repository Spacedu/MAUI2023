namespace AppMAUIGallery.Views.Components.Mains;

public partial class ImageButtonPage : ContentPage
{
	bool buttonState = false;
	public ImageButtonPage()
	{
		InitializeComponent();
	}

    private void ImageButton_Clicked(object sender, EventArgs e)
    {
		buttonState = !buttonState;

		var poweroff = "poweroff.png";
		var poweron = "poweron.png";

		var button = (ImageButton)sender;

		button.Source = (buttonState == false) ? ImageSource.FromFile(poweroff) : ImageSource.FromFile(poweron);
    }
}