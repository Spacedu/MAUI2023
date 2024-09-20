namespace AppTabbedPage;

public partial class Page1 : ContentPage
{
    public string Cliente { get; set; }
    public Page1()
	{
		InitializeComponent();
	}
    public void SetCliente(string cliente)
    {
        Cliente = cliente;
    }
}