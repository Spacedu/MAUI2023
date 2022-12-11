namespace AppMAUIGallery.Views.Components.Forms;

public partial class EntryPage : ContentPage
{
	public EntryPage()
	{
		InitializeComponent();
	}

    private void Entry_TextChanged(object sender, TextChangedEventArgs e)
    {
		LblText.Text = $"Antigo: {e.OldTextValue} - Novo: {e.NewTextValue}";
    }

    private void Entry_Completed(object sender, EventArgs e)
    {
        LblText.Text = "Concluído!";
    }
}