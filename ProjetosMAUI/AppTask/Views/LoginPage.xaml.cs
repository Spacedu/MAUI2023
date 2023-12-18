using AppTask.Database.Repositories;
using AppTask.Libraries.Authentations;
using AppTask.Libraries.Validations;
using AppTask.Models;
using AppTask.Services;

namespace AppTask.Views;

public partial class LoginPage : ContentPage
{
	private IUserService _service;
	private IUserModelRepository _repository;
    private StartPage _startPage;
    public LoginPage(IUserService service, IUserModelRepository repository, StartPage startPage)
    {
        InitializeComponent();

        _service = service;
        _repository = repository;
        _startPage = startPage;
    }

    private async void NextAction(object sender, EventArgs e)
    {
        var email = EntryEmail.Text.Trim().ToLower();

        LblEmailValidateMessage.IsVisible = false;
        if (!EmailValidate.IsValidEmail(email))
		{
			await _service.GetAccessToken(email);
            LblEmailValidateMessage.IsVisible = true;
			return;
        }

		EntryEmail.IsEnabled = false;
		BtnNext.IsVisible = false;
		Step2.IsVisible = true;
    }

    private async void AccessAction(object sender, EventArgs e)
    {
        var email = EntryEmail.Text.Trim().ToLower();
        var accessToken = EntryAccessToken.Text.Trim();

        LblAccessTokenValidateMessage.IsVisible = false;


        UserModel userAPI = await _service.ValidateAccessToken(new UserModel { Email = email, AccessToken = accessToken });
		if(userAPI != null)
		{
            var userDB = _repository.GetByEmail(userAPI.Email);
            
            if (userDB == null) 
                _repository.Add(userAPI);
            else
                _repository.Update(userAPI);
            

			UserAuth.SetUserLogged(userAPI);
			App.Current.MainPage = new NavigationPage(_startPage);
		}

		LblAccessTokenValidateMessage.IsVisible = true;
    }
}