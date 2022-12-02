using AppJogoForca.Models;
using AppJogoForca.Repositories;

namespace AppJogoForca
{
    public partial class MainPage : ContentPage
    {
        private Word _word;
        public MainPage()
        {
            InitializeComponent();

            var repository = new WordRepositories();
            _word = repository.GetRandomWord();

            LblTips.Text = _word.Tips;
            LblText.Text = new string('_', _word.Text.Length);
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            String letter = ((Button)sender).Text;
        }
    }
}