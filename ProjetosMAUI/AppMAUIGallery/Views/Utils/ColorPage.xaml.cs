namespace AppMAUIGallery.Views.Utils;

public partial class ColorPage : ContentPage
{
	public ColorPage()
	{
		InitializeComponent();

		Color.FromRgb(42, 31, 230);
		Color.FromRgba(42, 31, 230, 255);
	}
}