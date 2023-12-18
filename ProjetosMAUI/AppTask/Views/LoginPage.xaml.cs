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
        AILoading.IsVisible = true;
        EntryEmail.IsEnabled = false;
        var email = EntryEmail.Text?.Trim().ToLower();

        LblEmailValidateMessage.IsVisible = false;
        if (email == null || !EmailValidate.IsValidEmail(email))
		{
            EntryEmail.IsEnabled = true;
            AILoading.IsVisible = false;
            LblEmailValidateMessage.IsVisible = true;
			return;
        }

        await _service.GetAccessToken(email);
        EntryEmail.IsEnabled = false;
		BtnNext.IsVisible = false;
		Step2.IsVisible = true;
        AILoading.IsVisible = false;
    }

    private async void AccessAction(object sender, EventArgs e)
    {
        AILoading.IsVisible = true;
        LblAccessTokenValidateMessage.IsVisible = false;

        var email = EntryEmail.Text.Trim().ToLower();
        var accessToken = EntryAccessToken.Text?.Trim();

        if (accessToken == null)
        {
            AILoading.IsVisible = false;
            LblAccessTokenValidateMessage.IsVisible = true;
            return;
        }
            

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
        AILoading.IsVisible = false;
    }
}