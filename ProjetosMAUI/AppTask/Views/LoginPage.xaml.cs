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
}