namespace AppMAUIGallery.Views.Animations;

public partial class BasicAnimation : ContentPage
{
	public BasicAnimation()
	{
		InitializeComponent();
	}

    private void Normal(object sender, EventArgs e)
    {
        Image.Scale = 1;
        Image.Opacity = 1;
        Image.TranslationX = 0;
        Image.TranslationY = 0;
        Image.Rotation = 0;
        Image.RotationX = 0;
        Image.RotationY = 0;
    }
    private void Aumentar(object sender, EventArgs e)
    {
        Image.ScaleTo(2, 2000);
    }

    private void Diminuir(object sender, EventArgs e)
    {
        Image.ScaleTo(0.5, 2000);
    }

    private void Mover(object sender, EventArgs e)
    {
        Image.TranslateTo(0, 90, 2000, Easing.BounceOut);
    }

    private async void Rotacao(object sender, EventArgs e)
    {
        //await Image.RotateTo(720, 2000);
        //await Image.RotateYTo(360, 1000);
        await Image.RelRotateTo(90, 1000);
    }

    private async void Transparencia(object sender, EventArgs e)
    {
        await Image.FadeTo(0.3, 1000);
    }

    private async void Sequencial(object sender, EventArgs e)
    {
        await Image.TranslateTo(100, 0, 250);
        await Image.TranslateTo(-100, 0, 500);
        await Image.TranslateTo(0, 0, 250);
    }

    private async void Paralelo(object sender, EventArgs e)
    {
        await Task.WhenAll(
            Image.TranslateTo(100, 0, 4000),
            Image.RotateTo(360, 4000),
            Image.FadeTo(0.6, 4000)
        );
    }

    private void Cancelamento(object sender, EventArgs e)
    {
        Image.CancelAnimations();
    }
}