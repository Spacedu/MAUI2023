namespace AppShoppingCenter
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("stores/detail", typeof(Views.Stores.DetailPage));
            Routing.RegisterRoute("restaurants/detail", typeof(Views.Restaurants.DetailPage));
            Routing.RegisterRoute("cinemas/detail", typeof(Views.Cinemas.DetailPage));
        }
    }
}