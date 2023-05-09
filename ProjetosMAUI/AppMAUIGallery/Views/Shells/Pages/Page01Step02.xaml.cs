namespace AppMAUIGallery.Views.Shells.Pages;

public partial class Page01Step02 : ContentPage
{
	public Page01Step02()
	{
		InitializeComponent();
	}

    private void GoToRegisterStep02(object sender, EventArgs e)
    {
        // Rota atual: page01/page01step02

        //Rotas: cadastro/pessoa/editar/passo3

        //Relativas: cadastro/passo2
        //Shell.Current.GoToAsync("../../cadastro/passo2");

        //Rota Absoluta: //cadastro/passo2
        Shell.Current.GoToAsync("//cadastro/passo2");


    }

    private void GoToRegisterStep01(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("///passo1");
    }
}