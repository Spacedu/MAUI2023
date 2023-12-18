using AppTask.Database.Repositories;
using AppTask.Libraries.Authentations;
using AppTask.Models;

namespace AppTask.Views;

public partial class StartPage : ContentPage
{
    private ITaskModelRepository _repository;
    private AddEditTaskPage _addEditTaskPage;
    public StartPage(ITaskModelRepository repository, AddEditTaskPage addEditTaskPage)
    {
        InitializeComponent();

        _repository = repository;
        _addEditTaskPage = addEditTaskPage;
        LoadData();

        LblEmail.Text = UserAuth.GetUserLogged().Email;
    }

    private IList<TaskModel> _tasks;

    public void LoadData()
    {
        _tasks = _repository.GetAll(UserAuth.GetUserLogged().Id);
        CollectionViewTasks.ItemsSource = _tasks;
        LblEmptyText.IsVisible = _tasks.Count <= 0;        
    }

    private void OnButtonClickedToAdd(object sender, EventArgs e)
    {
        _addEditTaskPage = Handler.MauiContext.Services.GetService<AddEditTaskPage>();
        Navigation.PushModalAsync(_addEditTaskPage);
    }

    private void OnBorderClickedToFocusEntry(object sender, TappedEventArgs e)
    {
        Entry_Search.Focus();
    }

    private async void OnImageClickedToDelete(object sender, TappedEventArgs e)
    {
        var task = (TaskModel)e.Parameter;
        var confirm = await DisplayAlert("Confirme a exclusão!", $"Tem certeza de que deseja excluir essa tarefa: {task.Name}?", "Sim", "Não");

        if (confirm) { 
            _repository.Delete(task);
            LoadData();
        }
    }

    private void OnCheckBoxClickedToComplete(object sender, TappedEventArgs e)
    {
        var checkbox = ((CheckBox)sender);
        var task = (TaskModel)e.Parameter;

        if (DeviceInfo.Platform != DevicePlatform.WinUI)
            checkbox.IsChecked = !checkbox.IsChecked;
        
        task.IsCompleted = checkbox.IsChecked;
        _repository.Update(task);
    }

    private void OnTapToEdit(object sender, TappedEventArgs e)
    {
        var task = (TaskModel)e.Parameter;


        _addEditTaskPage = Handler.MauiContext.Services.GetService<AddEditTaskPage>();
        _addEditTaskPage.SetFormToUpdate(_repository.GetById(task.Id));
        Navigation.PushModalAsync(_addEditTaskPage);
    }

    private void OnTextChanged_FilterList(object sender, TextChangedEventArgs e)
    {
        var word = e.NewTextValue;
        CollectionViewTasks.ItemsSource = _tasks.Where(a => a.Name.ToLower().Contains(word.ToLower())).ToList();
    }

    private void OnButtonClickedToLogout(object sender, EventArgs e)
    {
        UserAuth.Logout();

        var page = Handler.MauiContext.Services.GetService<LoginPage>();
        App.Current.MainPage = page;
    }
}