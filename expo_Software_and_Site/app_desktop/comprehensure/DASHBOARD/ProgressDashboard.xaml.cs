namespace comprehensure.DASHBOARD;

public partial class ProgressDashboard : ContentPage
{
	public ProgressDashboard()
	{
		InitializeComponent();
	}

    private async void BackButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}