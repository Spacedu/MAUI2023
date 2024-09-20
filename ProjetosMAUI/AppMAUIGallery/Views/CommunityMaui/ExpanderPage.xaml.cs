namespace AppMAUIGallery.Views.CommunityMaui;

public partial class ExpanderPage : ContentPage
{
	public ExpanderPage()
	{
		InitializeComponent();
	}

    private void OnTextChanged(object sender, TextChangedEventArgs e)
    {
        var entry = ((Entry)sender);
        if(entry.Text is not null)
            entry.CursorPosition = entry.Text.Length;
    }
}