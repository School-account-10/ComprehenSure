namespace comprehensure.DASHBOARD;

public partial class AllAboutUS_Dashboard : ContentPage
{
	public AllAboutUS_Dashboard()
	{
		InitializeComponent();
	}

    private async void BackButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}