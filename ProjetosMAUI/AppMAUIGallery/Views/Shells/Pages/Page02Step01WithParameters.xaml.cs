using AppMAUIGallery.Models;
using System.Web;

namespace AppMAUIGallery.Views.Shells.Pages;

[QueryProperty(nameof(Texto), "msg")]
[QueryProperty(nameof(Person), "person")]
public partial class Page02Step01WithParameters : ContentPage
{
	private string _texto;
	public string Texto
	{
		get { return _texto; }
		set { 
			_texto = value;
			LblMSGParameter.Text = _texto;
		}
	}

    private Person _person;
    public Person Person
    {
        get { return _person; }
        set
        {
            _person = value;
			LblPersonParameter.Text = $"A pessoa recebida é: {_person.Name}({_person.Email})";
        }
    }


    public Page02Step01WithParameters()
	{
		InitializeComponent();
	}
}