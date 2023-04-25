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

}