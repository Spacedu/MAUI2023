using AppJogoForca.Libraries.Text;
using AppJogoForca.Models;
using AppJogoForca.Repositories;

namespace AppJogoForca
{
    public partial class MainPage : ContentPage
    {
        private Word _word;
        private int _errors;
        public MainPage()
        {
            InitializeComponent();

            ResetScreen();
        }

        private async void OnButtonClicked(object sender, EventArgs e)
        {
            ((Button)sender).IsEnabled = false;
            String letter = ((Button)sender).Text;

            var positions = _word.Text.GetPositions(letter);

            if(positions.Count == 0)
            {
                _errors++;
                ImgMain.Source = ImageSource.FromFile($"forca{_errors + 1}.png");

                if(_errors == 6)
                {
                    await DisplayAlert("Perdeu!", "Você foi enforcado!", "Novo jogo");
                    ResetScreen();
                }
                return;
            }

            foreach(int position in positions)
            {
                LblText.Text = LblText.Text.Remove(position, 1).Insert(position, letter);
            }
        }


        private void ResetScreen()
        {
            ResetVirtualKeyboard();
            ResetErrors();
            GenerateNewWord();
        }
        private void GenerateNewWord()
        {
            var repository = new WordRepositories();
            _word = repository.GetRandomWord();

            LblTips.Text = _word.Tips;
            LblText.Text = new string('_', _word.Text.Length);
        }
        private void ResetErrors()
        {
            _errors = 0;
            ImgMain.Source = ImageSource.FromFile("forca1.png");
        }
        private void ResetVirtualKeyboard()
        {
            ResetVirtualLines((HorizontalStackLayout)KeyboardContainer.Children[0]);
            ResetVirtualLines((HorizontalStackLayout)KeyboardContainer.Children[1]);
            ResetVirtualLines((HorizontalStackLayout)KeyboardContainer.Children[2]);
        }
        private void ResetVirtualLines(HorizontalStackLayout horizontal)
        {
            foreach(Button button in horizontal.Children)
            {
                button.IsEnabled = true;
            }
        }
    }
}