using AppMAUIGallery.Views.Lists.Models;

namespace AppMAUIGallery.Views.Lists;

public partial class ListViewPage : ContentPage
{
	public ListViewPage()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        ListViewControl.ItemsSource = MovieList.GetList();
    }
}