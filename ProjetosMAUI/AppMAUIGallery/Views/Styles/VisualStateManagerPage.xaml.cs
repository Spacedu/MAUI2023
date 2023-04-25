namespace AppMAUIGallery.Views.Styles;

public partial class VisualStateManagerPage : ContentPage
{
	public VisualStateManagerPage()
	{
		InitializeComponent();
	}

    private void OnTappedChangeVisualState(object sender, TappedEventArgs e)
    {
		var label = (Label)sender;
		VisualStateManager.GoToState(label, "Tapped");
    }
}