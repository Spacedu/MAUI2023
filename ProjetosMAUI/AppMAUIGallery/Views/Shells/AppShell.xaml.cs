using AppMAUIGallery.Views.Shells.Pages;

namespace AppMAUIGallery.Views.Shells;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute("page01/page01step01", typeof(Page01Step01));
		Routing.RegisterRoute("page01/page01step02", typeof(Page01Step02));
		Routing.RegisterRoute("page02/page02step01", typeof(Page02Step01WithParameters));
	}
}