namespace comprehensure;

public partial class SignUpPage : ContentPage
{
	public SignUpPage()
	{
		InitializeComponent();
	}
	public async void BackButtonEvent(Object sender, EventArgs e)
	{
        await Navigation.PushAsync(new MainPage());
    }
}