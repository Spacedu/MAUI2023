using AppJogoForca.Libraries.Text;
using AppJogoForca.Models;
using AppJogoForca.Repositories;

namespace AppJogoForca
{
    public partial class MainPage : ContentPage
    {
        private Word _word;
        private int _errors = 0;
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
            ((Button)sender).IsEnabled = false;
            String letter = ((Button)sender).Text;

            var positions = _word.Text.GetPositions(letter);

            if(positions.Count == 0)
            {
                _errors++;
                return;
            }

            foreach(int position in positions)
            {
                LblText.Text = LblText.Text.Remove(position, 1).Insert(position, letter);
            }
        }
    }
}