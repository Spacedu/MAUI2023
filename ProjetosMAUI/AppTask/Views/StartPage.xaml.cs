using AppTask.Database.Repositories;
using AppTask.Libraries.Authentations;
using AppTask.Libraries.Synchronizations;
using AppTask.Models;
using AppTask.Services;

namespace AppTask.Views;

public partial class StartPage : ContentPage
{
    private ITaskModelRepository _repository;
    private AddEditTaskPage _addEditTaskPage;
    private ITaskService _service;
    public StartPage(ITaskModelRepository repository, AddEditTaskPage addEditTaskPage, ITaskService service)
    {
        InitializeComponent();

        _repository = repository;
        _addEditTaskPage = addEditTaskPage;
        _service = service;

        LoadData();

        LblEmail.Text = UserAuth.GetUserLogged().Email;
    }

    private IList<TaskModel> _tasks;

    public void LoadData()
    {
        _tasks = _repository.GetAll(UserAuth.GetUserLogged().Id).Where(a=>a.Deleted == null).ToList();
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

            NetworkAccess networkAccess = Connectivity.Current.NetworkAccess;
            if (networkAccess == NetworkAccess.Internet)
            {
                await _service.Delete(task.Id);

                //TODO - Tratar Exception, Fazer uma possível Sincronização dos dados....
            }
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

        //Enviar para o Servidor....
        NetworkAccess networkAccess = Connectivity.Current.NetworkAccess;
        if(networkAccess == NetworkAccess.Internet)
        {
            _service.Update(task);

            //TODO - Tratar Exception, Fazer uma possível Sincronização dos dados....
        }
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

    private async void OnButtonClickedToSync(object sender, EventArgs e)
    {
        var userId = UserAuth.GetUserLogged().Id;
        var date = SyncData.GetLastSyncDate();
        List<TaskModel> localTasks = (date is null) ? _repository.GetAll(userId).ToList() : _repository.GetAll(userId).Where(a => a.Updated >= date.Value).ToList();

        var serverTasks = await _service.BatchPush(userId, localTasks);

        //TODO - Algoritmo de atualização local.
        // - Algoritmo 2: Analise dados e ver os registros que precisam ser adicionados - alterados(deleted) (+/-Performance). //+ Performatico
        SynchronizationLocalDatabase(serverTasks);

        //TODO - App - Guarda a data da última Sincronização...
        SyncData.SetLastSyncDate(DateTimeOffset.Now);

        //TODO - App - Chamar LoadData.
    }

    private void SynchronizationLocalDatabase(List<TaskModel> serverTasks) {
        var userId = UserAuth.GetUserLogged().Id;

        var localTasks = _repository.GetAll(userId).ToList();

        var taskToLocalAdd = new List<TaskModel>();
        var taskToLocalUpdate = new List<TaskModel>();

        foreach (var serverTask in serverTasks) {
            var task = localTasks.FirstOrDefault(a => a.Id == serverTask.Id);
            if(task == null)
            {
                taskToLocalAdd.Add(serverTask);
            }
            else
            {
                if(task.Updated < serverTask.Updated)
                {
                    taskToLocalUpdate.Add(serverTask);
                }
            }
        }
        _repository.Add(taskToLocalAdd);
        _repository.Update(taskToLocalUpdate);
    }
}