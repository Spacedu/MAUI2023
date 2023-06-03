namespace AppShoppingCenter.Views.Tickets;

public partial class ScanPage : ContentPage
{
	public ScanPage()
	{
		InitializeComponent();
	}

    private void CursorFix(object sender, TextChangedEventArgs e)
    {
		Entry input = (Entry)sender;

		input.CursorPosition = input.Text.Length;
    }
}