using AppMAUIGallery.Models;
using AppMAUIGallery.Repositories;

namespace AppMAUIGallery.Views;

public partial class MainPage : ContentPage
{
    private IGroupComponentRepository _repository;
    private List<Component> _fullList;

    public MainPage()
	{
		InitializeComponent();

        _repository = new GroupComponentRepository();
        _fullList = _repository.GetComponents();


        ComponentCollection.ItemsSource = _fullList;
	}

    private void OnTapComponent(object sender, TappedEventArgs e)
    {
        var page = (Type)e.Parameter;

        ((FlyoutPage)App.Current.MainPage).Detail = new NavigationPage((Page)Activator.CreateInstance(page));
        ((FlyoutPage)App.Current.MainPage).IsPresented = false;
    }

    private void Entry_TextChanged(object sender, TextChangedEventArgs e)
    {
        var word = e.NewTextValue;

        _fullList.RemoveAt(0);

        /*
        ComponentCollection.ItemsSource = _repository.GetComponents()
            .Where(a=>a.Title.ToLower().Contains(word.ToLower()))
            .ToList();
        */
    }
}