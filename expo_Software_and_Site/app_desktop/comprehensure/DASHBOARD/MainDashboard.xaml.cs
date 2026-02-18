namespace comprehensure.DASHBOARD;

public partial class MainDashboard : ContentPage 
{
	public MainDashboard()
	{
		InitializeComponent();
	}

	private async void ProgressButton_Clicked(object sender, EventArgs e)
	{
		await DisplayAlert("progress button", "Hi", "hewo btw ok button");
        await Navigation.PushAsync(new ProgressDashboard());
    }
	private async void ModulesButton_Clicked(object sender, EventArgs e)
	{
		await DisplayAlert("modules button", "Hi", "hewo btw ok button");
        await Navigation.PushAsync(new ModulesDaskboard());
    }

	private async void ProfileButton_Clicked(object sender, EventArgs e)
	{
		await DisplayAlert("profile button", "Hi", "hewo btw ok button");
        await Navigation.PushAsync(new ProfileDashboard());
    }
	private async void AboutUsButton_Clicked(object sender, EventArgs e)
	{
		await DisplayAlert("About US button", "Hi", "hewo btw ok button");
        await Navigation.PushAsync(new AllAboutUS_Dashboard());
    }

}