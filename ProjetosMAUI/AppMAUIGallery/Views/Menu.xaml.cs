using AppMAUIGallery.Models;
using AppMAUIGallery.Repositories;

namespace AppMAUIGallery.Views;

public partial class Menu : ContentPage
{
	private IGroupComponentRepository _repository;
    public Menu()
	{
		InitializeComponent();

		//TODO - DI - Dependecy Injection
		_repository = new GroupComponentRepository();

		MenuCollection.ItemsSource = _repository.GetGroupComponents();
    }

	private void OnTapComponent(object sender, TappedEventArgs e)
	{
		var component = (Component)e.Parameter;

		if (component.IsReplaceMainPage == false)
		{
            ((FlyoutPage)App.Current.MainPage).Detail = new NavigationPage((Page)Activator.CreateInstance(component.Page));
            ((FlyoutPage)App.Current.MainPage).IsPresented = false;
		}
		else
		{
			App.Current.MainPage = (Page)Activator.CreateInstance(component.Page);
		}
		
    }

    private void OnTapInicio(object sender, TappedEventArgs e)
    {
        ((FlyoutPage)App.Current.MainPage).Detail = new NavigationPage(new AppMAUIGallery.Views.MainPage());
        ((FlyoutPage)App.Current.MainPage).IsPresented = false;
    }
}