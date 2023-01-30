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
        ListViewControl.ItemsSource = MovieList.GetList().Take(2);
    }

    private void ListViewControl_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var movie = (Movie)e.SelectedItem;

        App.Current.MainPage.DisplayAlert("Filme selecionado!", $"O filme selecionado é: {movie.Name}", "OK");
    }

    private async void ListViewControl_Refreshing(object sender, EventArgs e)
    {
        ListViewControl.IsRefreshing = true;
        await Task.Delay(3000);
        ListViewControl.ItemsSource = MovieList.GetList();

        ListViewControl.IsRefreshing = false;
    }
}