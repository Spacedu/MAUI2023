using AppMAUIGallery.Views.Lists.Models;

namespace AppMAUIGallery.Views.Lists;

public partial class CarouselViewPage : ContentPage
{
	public CarouselViewPage()
	{
		InitializeComponent();
		CarouselViewControl.ItemsSource = MovieList.GetList();
    }
}