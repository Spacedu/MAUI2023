using AppTask.Libraries.Validations;

namespace AppTask.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    private void NextAction(object sender, EventArgs e)
    {
		LblEmailValidateMessage.IsVisible = false;

        if (!EmailValidate.IsValidEmail(EntryEmail.Text))
		{
			//TODO - Acionar API para Enviar AccessToken por e-mail.
            LblEmailValidateMessage.IsVisible = true;
			return;
        }

		EntryEmail.IsEnabled = false;
		BtnNext.IsVisible = false;
		Step2.IsVisible = true;
    }

    private void AccessAction(object sender, EventArgs e)
    {
        LblAccessTokenValidateMessage.IsVisible = false;

        var code = EntryAccessToken.Text.Trim();

		//TODO - Validar o AccessToken com a API
		if(code == "2640")
		{
			//TODO - Gravar os dados do usuário no dispositivo e redirecionar para a Tela inicial (StartPage)
			App.Current.MainPage = new NavigationPage(new StartPage());
		}

		LblAccessTokenValidateMessage.IsVisible = true;
    }
}