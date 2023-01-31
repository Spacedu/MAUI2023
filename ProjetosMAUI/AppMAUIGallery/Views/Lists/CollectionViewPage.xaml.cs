using AppMAUIGallery.Views.Lists.Models;

namespace AppMAUIGallery.Views.Lists;

public partial class CollectionViewPage : ContentPage
{
	public CollectionViewPage()
	{
		InitializeComponent();

		CollectionViewControl.ItemsSource = MovieList.GetList().Take(5);
	}

    private async void RefreshView_Refreshing(object sender, EventArgs e)
	{
		((RefreshView)sender).IsRefreshing = true;

		await Task.Delay(3000);
		CollectionViewControl.ItemsSource = MovieList.GetList();

        ((RefreshView)sender).IsRefreshing = false;
    }
}