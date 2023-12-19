using AppTask.Database.Repositories;
using AppTask.Libraries.Authentations;
using AppTask.Models;
using AppTask.Services;
using System.Text;
using System.Threading.Tasks;

namespace AppTask.Views;

public partial class AddEditTaskPage : ContentPage
{
    private ITaskModelRepository _repository;
    private ITaskService _service;
    private TaskModel _task;
    
	public AddEditTaskPage(ITaskModelRepository repository, ITaskService service)
	{
		InitializeComponent();

        _repository = repository;
        _service = service;

        _task = new TaskModel();

        BindableLayout.SetItemsSource(BindableLayout_Steps, _task.SubTasks);
    }
    public void SetFormToUpdate(TaskModel task)
    {
        _task = task;
        FillFields();

        BindableLayout.SetItemsSource(BindableLayout_Steps, _task.SubTasks);
    }
    private void FillFields()
    {
        Entry_TaskName.Text = _task.Name;
        Editor_TaskDescription.Text = _task.Description;
        DatePicker_TaskDate.Date = _task.PrevisionDate.Date;
    }

    private void CloseModal(object sender, EventArgs e)
    {
		Navigation.PopModalAsync();
    }

    private void SaveData(object sender, EventArgs e)
    {
        //Obter os dados
        GetDataFromForm();
        //Validar os dados
        bool valid = ValidateData();
        //Salvar os dados
        if (valid) { 
            SaveInDatabase();
            //Fechar a tela
            Navigation.PopModalAsync();

            //Solicitar a atualização da listagem da tela anterior.
            UpdateListInStartPage();
        }

    }
    private void GetDataFromForm()
    {
        _task.Name = Entry_TaskName.Text;
        _task.Description = Editor_TaskDescription.Text;
        _task.PrevisionDate = DatePicker_TaskDate.Date;
        _task.PrevisionDate = _task.PrevisionDate.AddHours(23);
        _task.PrevisionDate = _task.PrevisionDate.AddMinutes(59);
        _task.PrevisionDate = _task.PrevisionDate.AddSeconds(59);

        _task.IsCompleted = false;
    }
    private bool ValidateData()
    {
        Label_TaskName_Required.IsVisible = false;
        Label_TaskDescription_Required.IsVisible = false;

        bool validResult = true;
        if (string.IsNullOrWhiteSpace(_task.Name))
        {
            Label_TaskName_Required.IsVisible = true;
            validResult = false;
        }
        if (string.IsNullOrWhiteSpace(_task.Description))
        {
            Label_TaskDescription_Required.IsVisible = true;
            validResult = false;
        }

        return validResult;
    }
    private void SaveInDatabase()
    {
        if (_task.Id == default(Guid)) { 
            _task.UserId = UserAuth.GetUserLogged().Id;
            _task.Created = DateTimeOffset.Now;
            _task.Updated = DateTimeOffset.Now;

            _repository.Add(_task);

            NetworkAccess networkAccess = Connectivity.Current.NetworkAccess;
            if (networkAccess == NetworkAccess.Internet)
            {
                _service.Add(_task);

                //TODO - Tratar Exception, Fazer uma possível Sincronização dos dados....
            }
        }
        else {
            _task.Updated = DateTimeOffset.Now;
            _repository.Update(_task);

            NetworkAccess networkAccess = Connectivity.Current.NetworkAccess;
            if (networkAccess == NetworkAccess.Internet)
            {
                _service.Update(_task);

                //TODO - Tratar Exception, Fazer uma possível Sincronização dos dados....
            }
        }

    }
    private void UpdateListInStartPage()
    {
        var navPage = (NavigationPage)App.Current.MainPage;
        var startPage = (StartPage)navPage.CurrentPage;
        startPage.LoadData();
    }


    private async void AddStep(object sender, EventArgs e)
    {
        var stepName = await DisplayPromptAsync("Etapa(subtarefa)", "Digite o nome da etapa(subtarefa):", "Adicionar", "Cancelar");

        if(!string.IsNullOrWhiteSpace(stepName))
        {
            _task.SubTasks.Add(new SubTaskModel { Name = stepName, IsCompleted = false });
        }
    }

    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);

        DatePicker_TaskDate.WidthRequest = width - 30;
    }

    private void OnTapToDelete(object sender, TappedEventArgs e)
    {
        _task.SubTasks.Remove((SubTaskModel)e.Parameter);
    }
}