using AppMAUIGallery.Repositories;

namespace AppMAUIGallery.Views;

public partial class MainPage : ContentPage
{
    private IGroupComponentRepository _repository;

    public MainPage()
	{
		InitializeComponent();

        _repository = new GroupComponentRepository();

        ComponentCollection.ItemsSource = _repository.GetComponents();
	}

    private void OnTapComponent(object sender, TappedEventArgs e)
    {
        var page = (Type)e.Parameter;

        ((FlyoutPage)App.Current.MainPage).Detail = new NavigationPage((Page)Activator.CreateInstance(page));
        ((FlyoutPage)App.Current.MainPage).IsPresented = false;
    }
}