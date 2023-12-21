using AppTask.Database.Repositories;
using AppTask.Libraries.Authentations;
using AppTask.Libraries.Validations;
using AppTask.Models;
using AppTask.Services;
using System.Linq.Expressions;

namespace AppTask.Views;

public partial class LoginPage : ContentPage
{
	private IUserService _service;
	private IUserModelRepository _repository;
    
    public LoginPage(IUserService service, IUserModelRepository repository)
    {
        InitializeComponent();

        _service = service;
        _repository = repository;
    }

    private async void NextAction(object sender, EventArgs e)
    {
        AILoading.IsVisible = true;
        EntryEmail.IsEnabled = false;
        LblEmailValidateMessage.IsVisible = false;

        try
        {
            var email = GetEmailFromEntry();

            if (email == null || !EmailValidate.IsValidEmail(email))
            {
                ShowInvalidEmailMessage();
                return;
            }

            await _service.GetAccessToken(email);
            GoToStep2();
        }
        catch (HttpRequestException)
        {
            await ShowNetworkErrorAlert();
            EntryEmail.IsEnabled = true;
            //TODO - Logs...
        }
        catch (Exception)
        {
            await ShowUnexpectedErrorAlert();
            EntryEmail.IsEnabled = true;
            //TODO - Logs...
        }
        finally
        {
            AILoading.IsVisible = false;
        }
    }

    private async void AccessAction(object sender, EventArgs e)
    {
        AILoading.IsVisible = true;
        LblAccessTokenValidateMessage.IsVisible = false;
        EntryAccessToken.IsEnabled = false;
        try
        {
            var email = GetEmailFromEntry();
            var accessToken = EntryAccessToken.Text?.Trim();

            if (accessToken == null)
            {
                AILoading.IsVisible = false;
                LblAccessTokenValidateMessage.IsVisible = true;
                return;
            }

            UserModel userAPI = await _service.ValidateAccessToken(new UserModel { Email = email, AccessToken = accessToken });

            if(userAPI == null)
            {
                LblAccessTokenValidateMessage.IsVisible = true;
                return;
            }
            
            AddOrUpdateUserInDatabase(userAPI);

            UserAuth.SetUserLogged(userAPI);
            var startPage = Handler.MauiContext.Services.GetService<StartPage>();
            App.Current.MainPage = new NavigationPage(startPage);
        }
        catch (HttpRequestException)
        {
            await ShowNetworkErrorAlert();            
            //TODO - Logs...
        }
        catch (Exception)
        {
            await ShowUnexpectedErrorAlert();            
            //TODO - Logs...
        }
        finally
        {
            EntryAccessToken.IsEnabled = true;
            AILoading.IsVisible = false;
        }
    }

    private void AddOrUpdateUserInDatabase(UserModel userAPI)
    {
        var userDB = _repository.GetByEmail(userAPI.Email);

        if (userDB == null)
            _repository.Add(userAPI);
        else
            _repository.Update(userAPI);
    }

    private string GetEmailFromEntry()
    {
        return EntryEmail.Text?.Trim().ToLower();
    }

    private void ShowInvalidEmailMessage()
    {
        EntryEmail.IsEnabled = true;
        AILoading.IsVisible = false;
        LblEmailValidateMessage.IsVisible = true;
    }
    private void GoToStep2()
    {
        EntryEmail.IsEnabled = false;
        BtnNext.IsVisible = false;
        Step2.IsVisible = true;
        AILoading.IsVisible = false;
    }

    private async Task ShowUnexpectedErrorAlert()
    {
        await DisplayAlert("Opps! Ocorreu um erro inesperado", "Houve um erro no aplicativo, tente realizar o procedimento novamente!", "Ok");
    }

    private async Task ShowNetworkErrorAlert()
    {
        await DisplayAlert("Opps! Erro na rede!", "Não conseguimos se comunicar com o servidor! Tente novamente mais tarde!", "Ok");
    }
}