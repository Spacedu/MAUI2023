using System.Web;

namespace AppMAUIGallery.Views.Shells.Pages;

[QueryProperty(nameof(Texto), "msg")]
public partial class Page02Step01WithParameters : ContentPage
{
	private string _texto;
	public string Texto
	{
		get { return _texto; }
		set { 
			_texto = HttpUtility.UrlDecode( value );
			LblParameter.Text = _texto;
		}
	}

	public Page02Step01WithParameters()
	{
		InitializeComponent();
	}
}